using UniRx;
using UnityEngine;

namespace Sample.Section3.FactoryMethods
{
    public class EveryUpdateSample : MonoBehaviour
    {
        private void Start()
        {
            // Update 更新坐标
            Observable.EveryUpdate()
                .Subscribe(_ =>
                {
                    transform.position += Vector3.forward * Time.deltaTime;
                })
                .AddTo(this); // GameObject 销毁时 停止
        }
    }
}