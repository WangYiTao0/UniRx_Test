using System;
using UniRx;
using UnityEngine;

namespace Sample.Section3.FactoryMethods
{
    public class IntervalSample : MonoBehaviour
    {
        private void Start()
        {
            // Interval
            // Subscribe()后等待1s发送消息
            // (等待1s、然后每隔1s 发送消息）
            Observable.Interval(TimeSpan.FromSeconds(1))
                .Subscribe()
                .AddTo(this); // GameObject 销毁时 Dispose()
            // 比较 Observable.Timer
            // Subscribe() 时立刻发送消息、然后每隔1s 发送消息
            Observable.Timer(TimeSpan.Zero, TimeSpan.FromSeconds(1))
                .Subscribe()
                .AddTo(this);  // GameObject 销毁时 Dispose()
        }
    }
}