using System;
using UniRx;
using UnityEngine;

namespace Sample.Section3.FactoryMethods
{
    public class TimerSample1 : MonoBehaviour
    {
        private void Start()
        {
            // 一秒后 发送
            var timer = Observable.Timer(dueTime: TimeSpan.FromSeconds(1));
            Debug.Log("Subscribe 时刻:" + Time.time);
            
            timer.Subscribe(x =>
            {
                Debug.Log("OnNext 发送时刻:" + Time.time);
                Debug.Log("OnNext 里面:" + x);
            }, () => Debug.Log("OnCompleted"));
        }
    }
}