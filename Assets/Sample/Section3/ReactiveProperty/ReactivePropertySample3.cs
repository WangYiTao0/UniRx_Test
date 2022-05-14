using UnityEngine;
using UniRx;

namespace Sample.Section3.ReactiveProperty
{
    public class ReactivePropertySample3 : MonoBehaviour
    {
        private void Start()
        {
            var health = new ReactiveProperty<int>(100);
            health
                // Subscribe()后的无视OnNext消息
                .SkipLatestValueOnSubscribe()
                .Subscribe(x => Debug.Log("通知的值:" + x));

            health.Value = 50;
            health.Dispose();
        }
    }
}