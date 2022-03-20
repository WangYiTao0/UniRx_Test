using System;
using System.Collections;
using UniRx;
using UnityEngine;

namespace Sample.Section3.Subjects.Async
{
    //游戏资源的读取
    public class GameResourceProvider : MonoBehaviour
    {
        //Player Texture 管理
        private readonly AsyncSubject<Texture> _playerTextureAsyncSubject = new AsyncSubject<Texture>();

        //外部调用
        public IObservable<Texture> PlayerTextureAsync => _playerTextureAsyncSubject;

        private void Start()
        {
            //启动时加载资源
            StartCoroutine(LoadTexture());
        }

        private IEnumerator LoadTexture()
        {
            // 异步加载图片
            var resource = Resources.LoadAsync<Texture>("Textures/player");
            yield return resource;
            // 读取完后再发送消息
            _playerTextureAsyncSubject.OnNext(resource.asset as Texture);
            _playerTextureAsyncSubject.OnCompleted();
        }
    }
}