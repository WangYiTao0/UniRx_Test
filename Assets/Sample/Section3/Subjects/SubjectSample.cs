using UniRx;
using UnityEngine;

namespace Sample.Section3.Subjects
{
    public class SubjectSample : MonoBehaviour
    {
        private void Start()
        {
            var subject = new Subject<int>();
            //发送消息
            subject.OnNext(1);
            //订阅
            subject.Subscribe(
                x => Debug.Log("OnNext:" + x),
                ex => Debug.LogError("OnError:" + ex),
                () => Debug.Log("OnCompleted"));
            //发送消息
            subject.OnNext(2);
            subject.OnNext(3);
            subject.OnCompleted();
            // Dispose()
            subject.Dispose();
            
            /*
                OnNext:2
                OnNext:3
                OnCompleted
             */
        }
    }
}