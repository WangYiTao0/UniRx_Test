using UniRx;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Sample.Section3.FactoryMethods
{
    public class UnityWebRequestToObservable : MonoBehaviour
    {
        private void Start()
        {
            // UniTask => Observable
            FetchAsync("http://www.baidu.com/")
                .ToObservable()
                .Subscribe(x => Debug.Log(x));
        }
        // 用 UnityWebRequest 进行HTTP通信
        private async UniTask<string> FetchAsync(string uri)
        {
            using (var uwr = UnityWebRequest.Get(uri))
            {
                // UniTask 可以 await
                await uwr.SendWebRequest();
                return uwr.downloadHandler.text;
            }
        }
    }
}