using UniRx;
using UnityEngine;

namespace Sample.Section3.FactoryMethods
{
    public class RangeSample : MonoBehaviour
    {
        private void Start()
        {
            // 从0 开始 发送5个 连续增加 的消息
            Observable.Range(start: 0, count: 5)
                .Subscribe(
                    x => Debug.Log("OnNext:" + x),
                    ex => Debug.LogError("OnError:" + ex.Message),
                    () => Debug.Log("OnCompleted")
                );
        }
    }
}