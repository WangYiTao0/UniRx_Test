using System;
using System.IO;
using UniRx;
using UnityEngine;

namespace Sample.Section3.FactoryMethods
{
    public class FromAsyncPatternSample : MonoBehaviour
    {
        private void Start()
        {
            // 指定文件名，读取后返回结果的 委托
            Func<string, string> readFile = fileName =>
            {
                using (var r = new StreamReader(fileName))
                {
                    return r.ReadToEnd();
                }
            };
            
            // 委托进行异步处理，并把结果作为Observable 
            // 返回值也是委托
            Func<string, IObservable<string>> f =
                Observable.FromAsyncPattern<string, string>(
                    readFile.BeginInvoke,
                    readFile.EndInvoke);
            
            // 委托执行时 异步开始
            // 内部使用的是 AsyncSubject 
            IObservable<string> readAsync = f("data.txt");
            // 订阅结果
            readAsync.Subscribe(x => Debug.Log(x));
        }
    }
}