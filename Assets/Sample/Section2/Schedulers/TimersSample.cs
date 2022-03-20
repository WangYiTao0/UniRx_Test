using System;
using System.Threading;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;

namespace Sample.Section2.Schedulers
{
    public class TimersSample : MonoBehaviour
    {
        private void Start()
        {
            // 指定MainThread 
            //「1秒后的和Update相同的时机执行 」
            Observable.Timer(TimeSpan.FromSeconds(1), Scheduler.MainThread)
                .Subscribe(x => Debug.Log("Scheduler.MainThread " +"经过1秒 " + "Thread Id:" + Thread.CurrentThread.ManagedThreadId))
                .AddTo(this);
            // 默认是 MainThreadScheduler 
            Observable.Timer(TimeSpan.FromSeconds(1))
                .Subscribe(x => Debug.Log("Default MainThreadScheduler " + "经过1秒 " + "Thread Id:" + Thread.CurrentThread.ManagedThreadId))
                .AddTo(this);
            // 指定 MainThreadEndOfFrame 
            //「1秒后 在Frame Rendering后 执行 」
            Observable.Timer(TimeSpan.FromSeconds(1), Scheduler.MainThreadEndOfFrame)
                .Subscribe(x => Debug.Log("Scheduler.MainThreadEndOfFrame " +"经过1秒 " + "Thread Id:" + Thread.CurrentThread.ManagedThreadId))
                .AddTo(this);
            // 指定 CurrentThread  
            // 这里实在新做的线程上执行
            new Thread(() =>
            {
                Observable.Timer(TimeSpan.FromSeconds(1), Scheduler.CurrentThread)
                    .Subscribe(x => Debug.Log("new Thread " +"经过1秒 " + "Thread Id:" + Thread.CurrentThread.ManagedThreadId));
                //.AddTo(this);
            }).Start(); 
            
            /*
             * new Thread 经过1秒 Thread Id:419
             * Scheduler.MainThread 经过1秒 Thread Id:1
             * Default MainThreadScheduler 经过1秒 Thread Id:1
             * Scheduler.MainThreadEndOfFrame 经过1秒 Thread Id:1
             */
        }
    }
}