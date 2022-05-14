using UniRx;
using UnityEngine;

namespace Sample.Section3.ReactiveProperty
{
    public class ReactivePropertySample : MonoBehaviour
    {
        private void Start()
        {
            // int 型的ReactiveProperty
            // 初期値是100  
            var health = new ReactiveProperty<int>(100);
            // .Value 读取现在设定的值
            Debug.Log("現在の値:" + health.Value);
            // ReactiveProperty 可以直接被 Subscribe
            // Subscribe 时 会发行当前设定的值的消息
            health.Subscribe(
                x => Debug.Log("现在通知值:" + x),
                () => Debug.Log("OnCompleted"));
            // .Value 赋值时 、发行OnNext 消息
            health.Value = 50;
            Debug.Log("现在的值:" + health.Value);
            // Dispose()时发行 OnCompleted 消息
            health.Dispose();
        }
    }
}
