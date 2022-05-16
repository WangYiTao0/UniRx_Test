using System;
using UniRx;
using UnityEngine;

namespace Sample.Section3.FactoryMethods
{
    public class TimerFrameSample2 : MonoBehaviour
    {
        private void Start()
        {
            var timer = Observable.TimerFrame(dueTimeFrameCount: 5, periodFrameCount: 10);
            Debug.Log("Subscribe() 时的Frame :" + Time.frameCount);
            timer.Subscribe(
                x => Debug.Log($"{x} - {Time.frameCount}"),
                () => Debug.Log("OnCompleted")
            ).AddTo(this); // 不要忘记Dispose()
        }
    }
}