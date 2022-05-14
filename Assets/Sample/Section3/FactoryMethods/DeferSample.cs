using UniRx;
using UnityEngine;

namespace Sample.Section3.FactoryMethods
{
    public class DeferSample : MonoBehaviour
    {
        private void Start()
        {
            //在 Subscribe() 时生成 「返回随机数的Observable」
            var rand = Observable.Defer(() =>
            {
                // 随机数
                var randomValue = UnityEngine.Random.Range(0, 100);
                // 返回随机数的 Observable
                return Observable.Return(randomValue);
            });
            // 复数回 Subscribe
            rand.Subscribe(x => Debug.Log(x));
            rand.Subscribe(x => Debug.Log(x));
            rand.Subscribe(x => Debug.Log(x));
        }
    }
}