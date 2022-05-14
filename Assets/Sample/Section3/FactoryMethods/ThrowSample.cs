using System;
using UniRx;
using UnityEngine;

namespace Sample.Section3.FactoryMethods
{
    public class ThrowSample : MonoBehaviour
    {
        private void Start()
        {
            // int を扱うObservable からOnError メッセージを発行する
            Observable.Throw<int>(new Exception("发生错误"))
                .Subscribe(
                    x => Debug.Log("OnNext:" + x),
                    ex => Debug.LogError("OnError:" + ex.Message),
                    () => Debug.Log("OnCompleted")
                );
        }
    }
}