using System;
using UnityEngine;
using UniRx;

namespace Sample.Section3.FactoryMethods
{
    public class ToObservableSample : MonoBehaviour
    {
        private void Start()
        {
            // string 数组
            string[] strArray = new[] { "apple", "banana", "lemon" };
            // 数组 变成 Observable  并顺序发送消息
            strArray.ToObservable()
                .Subscribe(
                    x => Debug.Log("OnNext:" + x),
                    ex => Debug.LogError("OnError:" + ex.Message),
                    () => Debug.Log("OnCompleted"));
        }
    }
}