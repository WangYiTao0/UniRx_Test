using System;
using System.IO;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;

namespace Sample.Section3.FactoryMethods
{
    public class StartSample : MonoBehaviour
    {
        private void Start()
        {
            // Observable.Start<T>的返回值 是 IObservable<T>
            Observable.Start(() =>
                {
                    // 读取文件
                    using (var r = new StreamReader(@"data.txt"))
                    {
                        // 读取的结果用Observable
                        return r.ReadToEnd();
                    }
                }, Scheduler.ThreadPool)
                .Subscribe(x => Debug.Log(x)); // Start()的返回值可以 直接Subscribe 
        }
    }
}