using UniRx;
using UnityEngine;

namespace Sample.Section3.FactoryMethods
{
    public class OnceApplicationQuitSample : MonoBehaviour
    {
        private void Start()
        {
            // OnApplicationQuit　时发送消息
            Observable.OnceApplicationQuit()
                .Subscribe(_ => Debug.Log("OnApplicationQuit"));
        }
    }
}