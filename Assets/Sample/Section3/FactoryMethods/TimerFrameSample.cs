using System;
using UniRx;
using UnityEngine;

namespace Sample.Section3.FactoryMethods
{
    public class TimerFrameSample : MonoBehaviour
    {
        private void Start()
        {
            var timer = Observable.TimerFrame(dueTimeFrameCount: 5);
            Debug.Log("Subscribe() 时的Frame :" + Time.frameCount);
            timer.Subscribe(x =>
            {
                Debug.Log("OnNext 时的Frame:" + Time.frameCount);
                Debug.Log("OnNext :" + x);
            }, () => Debug.Log("OnCompleted"));
        }
    }
}