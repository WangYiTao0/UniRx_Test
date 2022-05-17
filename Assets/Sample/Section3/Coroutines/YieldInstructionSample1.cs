using System;
using System.Collections;
using UniRx;
using UnityEngine;

namespace Sample.Section3.Coroutines
{
    public class YieldInstructionSample1 : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine(WaitCoroutine());
        }
        private IEnumerator WaitCoroutine()
        {
            Debug.Log("Coroutine start:" + Time.time);
            // Observable => Coroutine
            yield return Observable
                .Timer(TimeSpan.FromSeconds(1))
                .ToYieldInstruction();
            Debug.Log("Coroutine end:" + Time.time);
        }
    }
}