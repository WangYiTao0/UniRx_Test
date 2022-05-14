using System;
using UniRx;
using UnityEngine;

namespace Sample.Section3.FactoryMethods
{
    public class CreateSample : MonoBehaviour
    {
        private void Start()
        {
            // 从 Ａ　开始　顺序生成　字母
            var observable = Observable.Create<char>(observer =>
            {
                // 带有　IDisposable 和　CancellationToken的　Ｏｂｊｅｃｔ 
                // Dispose()　时　出去　Cancel状态
                var disposable = new CancellationDisposable();
                // 线程池上执行　
                Task.Run(async () =>
                {
                    // 发行　'A' - 'Z' 
                    for (var i = 0; i < 26; i++)
                    {
                        // 等待　１秒
                        await Task.Delay(TimeSpan.FromSeconds(1), disposable.Token);
                        // 发行　文字
                        observer.OnNext((char) ('A' + i));
                    }
                    // 发行完了　发送　OnCompleted
                    observer.OnCompleted();
                }, disposable.Token);
                // Subscribe()中断的同时
                // CancellationToken 已经是Canel状态了
                return disposable;
            });
            // 订阅
            observable.Subscribe(
                x => Debug.Log("OnNext:" + x),
                ex => Debug.LogError("OnError:" + ex.Message),
                () => Debug.Log("OnCompleted")
            ).AddTo(this);
        }
    }
}