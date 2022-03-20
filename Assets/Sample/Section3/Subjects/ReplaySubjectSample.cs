using UniRx;
using UnityEngine;

namespace Sample.Section3.Subjects
{
    public class ReplaySubjectSample : MonoBehaviour
    {
        private void Start()
        {
            // ReplaySubject 缓存过去的3个消息
            var subject = new ReplaySubject<int>(bufferSize: 3);
            // 发送消息
            for (int i = 0; i < 10; i++)
            {
                subject.OnNext(i);
            }
            // OnCompleted 也会被缓存
            subject.OnCompleted();
            // OnError 也会被缓存
            // subject.OnError(new Exception("Error!"));
            // 订阅
            subject.Subscribe(
                x => Debug.Log("OnNext:" + x),
                ex => Debug.LogError("OnError:" + ex),
                () => Debug.Log("OnCompleted"));
            subject.Dispose();
            
            /*
                OnNext:7
                OnNext:8
                OnNext:9
                OnCompleted
             */
        }
    }
}