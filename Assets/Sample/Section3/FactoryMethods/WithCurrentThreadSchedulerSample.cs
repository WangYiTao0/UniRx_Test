using System;
using UniRx;
using UnityEngine;

namespace Sample.Section3.FactoryMethods
{
    public class WithCurrentThreadSchedulerSample : MonoBehaviour
    {
        private void Start()
        {
            // 指定 CurrentThreadScheduler 
            Observable.Range(
                start: 0,
                count: 5,
                scheduler: Scheduler.CurrentThread
            ).Subscribe(x =>
            {
                //  表示当前 Frame
                Debug.Log($"frame:{Time.frameCount} value:{x}");
            });
        }
    }
}