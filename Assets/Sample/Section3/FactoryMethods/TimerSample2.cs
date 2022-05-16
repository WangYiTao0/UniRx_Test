using System;
using UniRx;
using UnityEngine;

namespace Sample.Section3.FactoryMethods
{
    public class TimerSample2 : MonoBehaviour
    {
        private void Start()
        {
            // 等1s 每0.5s 发送一次消息
            var timer = Observable.Timer(
                dueTime: TimeSpan.FromSeconds(1),
                period: TimeSpan.FromSeconds(0.5));
            Debug.Log("Subscribe 的时间:" + Time.time);
            timer.Subscribe(
                x => Debug.Log($"[{x}]:{Time.time}"),
                () => Debug.Log("OnCompleted")
            )
            //GameObject 被销毁前 会无限Loop
            .AddTo(this); // Dispose()の実行を忘れない
        }
    }
}