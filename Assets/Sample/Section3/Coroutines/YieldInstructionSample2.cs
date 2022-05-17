using System.Collections;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Sample.Section3.Coroutines
{
    public class YieldInstructionSample2 : MonoBehaviour
    {
        [SerializeField] private Button _moveButton;
        private void Start()
        {
            StartCoroutine(MoveCoroutine());
        }
        // 按下 Button 在1秒间 Object 会前进
        private IEnumerator MoveCoroutine()
        {
            while (true)
            {
                // 等待 Button 按下
                // OnClickAsObservable()是无限长的Stream、使用Take(1) 执行1次
                yield return _moveButton
                    .OnClickAsObservable()
                    .Take(1)
                    .ToYieldInstruction();
                var start = Time.time;
                while (Time.time - start <= 1.0f)
                {
                    //前进
                    transform.position += Vector3.forward * Time.deltaTime;
                    yield return null;
                }
            }
        }
    }
}