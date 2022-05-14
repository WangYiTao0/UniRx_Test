using UniRx;
using UnityEngine;

namespace Sample.Section3.FactoryMethods
{
    public class WithMainThreadSchedulerSample : MonoBehaviour
    {
        private void Start()
        {
            //指定 MainThreadScheduler 
            Observable.Range(
                start: 0,
                count: 5,
                scheduler: Scheduler.MainThread
            ).Subscribe(x =>
            {
                //表示 当前的Frame
                Debug.Log($"frame:{Time.frameCount} value:{x}");
            });
        }
    }
}