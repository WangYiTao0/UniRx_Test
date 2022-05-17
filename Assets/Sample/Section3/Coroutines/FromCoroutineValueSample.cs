using System.Collections;
using UniRx;
using UnityEngine;

namespace Sample.Section3.Coroutines
{
    public class FromCoroutineValueSample : MonoBehaviour
    {
        private void Start()
        {
            Observable.FromCoroutineValue<Vector3>(PositionCoroutine, false)
                .Subscribe(
                    x => Debug.Log(x),
                    () => Debug.Log("OnCompleted"));
        }
        // 顺序返回坐标数组
        private IEnumerator PositionCoroutine()
        {
            var positions = new[]
            {
                new Vector3(0, 0, 0),
                new Vector3(0, 1, 0),
                new Vector3(0, 1, 1),
                new Vector3(1, 1, 1),
            };
            foreach (var p in positions)
            {
                yield return p;
            }
        }
    
    }
}