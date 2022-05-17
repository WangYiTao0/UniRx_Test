using System;
using System.Collections;
using UniRx;
using UnityEngine;

namespace Sample.Section3.Coroutines
{
    public class FromCoroutineSample1 : MonoBehaviour
    {
        private void Start()
        {
            // Coroutine 结束时用 Observable 接受消息
            Observable.FromCoroutine(WaitingCoroutine, publishEveryYield: false)
                .Subscribe(
                    _ => Debug.Log("OnNext"),
                    () => Debug.Log("OnCompleted"))
                .AddTo(this);
            // ToObservable()  简单写法 糖语法
            // WaitingCoroutine().ToObservable()
            // .Subscribe();
        }
    
        private IEnumerator WaitingCoroutine()
        {
            Debug.Log("Coroutine start.");
            // 等待3s
            yield return new WaitForSeconds(3);
            Debug.Log("Coroutine finish.");
        }
    }
}