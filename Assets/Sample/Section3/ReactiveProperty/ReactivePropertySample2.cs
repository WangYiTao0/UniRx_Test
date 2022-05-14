using UnityEngine;
using UniRx;

namespace Sample.Section3.ReactiveProperty
{
    public class ReactivePropertySample2 : MonoBehaviour
    {
        private void Start()
        {
            var health = new ReactiveProperty<int>(100);
            health
                .Subscribe(x => Debug.Log("通知的值:" + x));
            // x
            Debug.Log("<Value = 100>");
            health.Value = 100;
            // 强制发行消息使用SetValueAndForceNotify
            Debug.Log("<Value 强制更新>");
            health.SetValueAndForceNotify(100);

            health.Dispose();
        }
    }
}