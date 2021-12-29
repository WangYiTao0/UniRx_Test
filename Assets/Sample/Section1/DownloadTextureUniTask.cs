using System;
using System.Collections;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Sample.Section1.Async
{
    /// <summary>
    /// 下载指定的图片
    /// 设定到rawImage
    /// </summary>
    public class DownloadTextureUniTask : MonoBehaviour
    {
        /// <summary>
        /// UGUI 的 RawImage
        /// </summary>
        [SerializeField] private RawImage _rawImage;

        private void Start()
        {
            //取得 跟这个GameObject绑定的CancellationToken
            var token = this.GetCancellationTokenOnDestroy();
            
            //设置图片
            SetupTextureAsync(token).Forget();
        }

        private async UniTaskVoid SetupTextureAsync(CancellationToken token)
        {
            try
            {
                //想要表示的画像的address
                var url = "https://pbs.twimg.com/media/EVAhiXWUwAQx5oD?format=jpg&name=4096x4096";

                //想要使用UniRx的Retry，把UniRX变成 IObservable
                var observable = Observable
                    .Defer(() => 
                        //UniRx -> IObservable
                        GetTextureAsync(url, token).ToObservable()).Retry(3);

                //Observable 也可以使用await   
                var texture = await observable;

                _rawImage.texture = texture;
            }
            catch (Exception e)when (!(e is OperationCanceledException))
            {
                Debug.LogError(e);
            }
        }
        //使用async/await 代替 Coroutine
        private async UniTask<Texture> GetTextureAsync(string url, CancellationToken token)
        {
            using (var uwr = UnityWebRequestTexture.GetTexture(url))
            {
                await uwr.SendWebRequest().WithCancellation(token);
                return ((DownloadHandlerTexture) uwr.downloadHandler).texture;
            }
        }        
    }
}
