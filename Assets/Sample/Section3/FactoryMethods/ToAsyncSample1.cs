using System;
using System.IO;
using UniRx;
using UnityEngine;

namespace Sample.Section3.FactoryMethods
{
    public class ToAsyncSample1 : MonoBehaviour
    {
        private void Start()
        {
            // Observable.ToAsync  的返回值 Func<IObservable<T>>
            Func<IObservable<string>> fileReadFunc;
            // mainthread 上读取文件
            fileReadFunc = Observable.ToAsync(() =>
            {
                using (var r = new StreamReader(@"data.txt"))
                {
                    // 读取的结果 用Observable 
                    return r.ReadToEnd();
                }
            }, Scheduler.ThreadPool);
            // 为了开始异步处理，必须明确的调用方法
            fileReadFunc().Subscribe(x => Debug.Log(x));
            // Invoke()也行
            // fileReadFunc.Invoke().Subscribe();
        }
    }
}