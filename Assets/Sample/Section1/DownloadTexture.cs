using System;
using System.Collections;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Sample.Section1
{
    public class DownloadTexture : MonoBehaviour
    {
        /// <summary>
        /// UGUI 的 RawImage
        /// </summary>
        [SerializeField] private RawImage _rawImage;

        private void Start()
        {
            //想要表示的画像的address
            var url = "https://pbs.twimg.com/media/EVAhiXWUwAQx5oD?format=jpg&name=4096x4096";
            
            //取得Texture
            //例外发生时 尝试3回
            GetTextureAsync(url)
                .OnErrorRetry(
                    onError: (Exception _) => { },
                    retryCount: 3
                ).Subscribe(result => { _rawImage.texture = result; },
                    error => { Debug.Log(error); })
                .AddTo(this);
        }

        /// <summary>
        /// 启动Coroutine，并把结果用 Observable返回
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private IObservable<Texture> GetTextureAsync(string url)
        {
            return Observable.FromCoroutine<Texture>(observer =>
            {
                return GetTextureCoroutine(observer, url);
            });
        }

        /// <summary>
        /// 用Coroutine进行图片下载
        /// </summary>
        /// <param name="observer"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        private IEnumerator GetTextureCoroutine(IObserver<Texture> observer, string url)
        {
            using (var uwr = UnityWebRequestTexture.GetTexture(url))
            {
                yield return uwr.SendWebRequest();
                if (uwr.result == UnityWebRequest.Result.ConnectionError 
                    || uwr.result == UnityWebRequest.Result.ProtocolError)
                {
                    //Error发生时 发送 OnError 消息
                    observer.OnError(new Exception(uwr.error));
                    yield break;
                }

                var result = ((DownloadHandlerTexture) uwr.downloadHandler).texture;
                //成功时 发送OnNext/OnCompleted消息
                observer.OnNext(result);
                observer.OnCompleted();
            }
        }
    }
}
