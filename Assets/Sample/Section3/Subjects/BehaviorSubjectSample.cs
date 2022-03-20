using System;
using UniRx;
using UnityEngine;

namespace Sample.Section3.Subjects
{
    public class BehaviorSubjectSample : MonoBehaviour
    {
        private void Start()
        {
            
            // BehaviorSubject 要有初期值
            var behaviorSubject = new BehaviorSubject<int>(0);
            //发送消息
            behaviorSubject.OnNext(1);
            //订阅
            behaviorSubject.Subscribe(
                x => Debug.Log("OnNext:" + x),
                ex => Debug.LogError("OnError:" + ex),
                () => Debug.Log("OnCompleted"));
            //发送消息
            behaviorSubject.OnNext(2);
            // 打印暂存的值 和 现在的值比较
            Debug.Log("Last Value:" + behaviorSubject.Value);
            behaviorSubject.OnNext(3);
            behaviorSubject.OnCompleted();
            // Dispose
            behaviorSubject.Dispose();
            
            /*
             * OnNext:1
               OnNext:2
               Last Value:2
               OnNext:3
               OnCompleted
             */
        }
    }
}