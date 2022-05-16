using System;
using UniRx;
using UnityEngine;

namespace Sample.Section3.FactoryMethods
{
    public class CreateWithStateSample : MonoBehaviour
    {
        private void Start()
        {
            CreateCountObservable(10).Subscribe(x => Debug.Log(x));
        }

 
        // 返回指定个数的连续值的Observable
        private IObservable<int> CreateCountObservable(int count)
        {
            // count 为 0 时 发送OnCompleted
            if (count <= 0) return Observable.Empty<int>();
            // 指定的数值 连续 发送
            return Observable.CreateWithState<int, int>(
                state: count,
                subscribe: (maxCount, observer) =>
                {
                    // maxCount 为 State 指定的值
                    for (int i = 0; i < maxCount; i++)
                    {
                        observer.OnNext(maxCount);
                    }
                    observer.OnCompleted();
                    return Disposable.Empty;
                });
        }
    }
}