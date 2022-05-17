using System;
using System.Collections;
using System.Threading;
using UniRx;
using UnityEngine;

namespace Sample.Section3.Coroutines
{
    public class FromCoroutineSample2 : MonoBehaviour
    {
        private void Start()
        {
            //  使用 CancellationToken 
            Observable
                .FromCoroutine(token => WaitingCoroutine(token))
                .Subscribe(
                    _ => Debug.Log("OnNext"),
                    () => Debug.Log("OnCompleted"))
                .AddTo(this);
        }
        // CancellationToken 作为参数
        private IEnumerator WaitingCoroutine(CancellationToken token)
        {
            Debug.Log("Coroutine start.");
            // Observable 在等待Coroutine 时
            // 当这个Coroutine 停止时
            // yield return 让等待着的Observable 也停下来
            // 所以 使用 CancellationToken
            yield return Observable
                .Timer(TimeSpan.FromSeconds(3))
                
                .ToYieldInstruction(token); // 因为Observable 停下来了 到这会停止Coroutine
            
            Debug.Log("Coroutine finish.");
        }
    }
}