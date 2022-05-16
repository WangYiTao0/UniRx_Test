using UniRx;
using UnityEngine;

// Unity 2018.3之前 可以使用
namespace Sample.Section3.FactoryMethods
{
    public class ObservableWWWSample : MonoBehaviour
    {
        private void Start()
        {
            var uri = "https://unity3d.com";
            // 只接受文字结果
            ObservableWWW.Get(uri)
                .Subscribe(x => Debug.Log(x));
            // 通信结束时接受 www 
            ObservableWWW.GetWWW(uri)
                .Subscribe(www => Debug.Log(www.text));
        }
    }
}