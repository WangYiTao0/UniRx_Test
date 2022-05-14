using UniRx;
using UnityEngine;

namespace Sample.Section3.ReactiveProperty
{
    public class ReadOnlyReactivePropertySample : MonoBehaviour
    {
        private void Start()
        {
            //Int型的 ReactiveProperty
            var intReactiveProperty =
                new ReactiveProperty<int>(100);
            
            // int型的 ReadOnlyReactiveProperty
            var readOnlyInt = 
                // ReactiveProperty 变换成 ReadOnlyReactiveProperty
                intReactiveProperty.ToReadOnlyReactiveProperty();
            
            // 可读
            Debug.Log("现在的值:" + readOnlyInt.Value);
            //可以订阅
            readOnlyInt.Subscribe(x => Debug.Log("通知的值 :" + x));
            // 不可写
            // readOnlyInt.Value = 10;
            intReactiveProperty.Dispose();
        }
    }
}