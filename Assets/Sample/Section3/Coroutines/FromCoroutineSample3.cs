using System;
using System.Collections;
using UniRx;
using UnityEngine;

namespace Sample.Section3.Coroutines
{
    public class FromCoroutineSample3 : MonoBehaviour
    {
        //长按判定时间
        private readonly float _longPressThresholdSeconds = 1.0f;

        private void Start()
        {
            // 检测一定时间长按的Observable
            Observable.FromCoroutine<bool>(observer => LongPushCoroutine(observer))
                .DistinctUntilChanged() // 去除重复的消息
                .Subscribe(x => Debug.Log(x)).AddTo(this);
        }
        
        // 检测空格键被长按
        // 经过一定时间返回true
        // 放开按键 返回false
        private IEnumerator LongPushCoroutine(IObserver<bool> observer)
        {
            var isPushed = false;
            var lastPushTime = Time.time;
            while (true)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    if (!isPushed)
                    {
                        // 按下的时间
                        lastPushTime = Time.time;
                        isPushed = true;
                    }
                    else if (Time.time - lastPushTime > _longPressThresholdSeconds)
                    {
                        // 按下时发送true
                        observer.OnNext(true);
                    }
                }
                else
                {
                    if (isPushed)
                    {
                        // 抬起时发送false
                        observer.OnNext(false);
                        isPushed = false;
                    }
                }

                yield return null;
            }
        }
    }
}