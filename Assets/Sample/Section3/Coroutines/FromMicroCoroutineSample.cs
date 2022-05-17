using System.Collections;
using UniRx;
using UnityEngine;

namespace Sample.Section3.Coroutines
{
    public class FromMicroCoroutineSample : MonoBehaviour
    {
        private void Start()
        {
            // FromCoroutine 
            Observable
                .FromCoroutine(() => WaitingCoroutine(5))
                .Subscribe();
            // 对象协程只使用了 yield return null
            // 可以使用　FromMicroCoroutine 　
            Observable
                .FromMicroCoroutine(() => WaitingCoroutine(5))
                .Subscribe();
        }
        // 等待指定秒数
        private IEnumerator WaitingCoroutine(float seconds)
        {

            var start = Time.time;
            while (Time.time - start <= seconds)
            {
                yield return null;
            }
        }
    }
}