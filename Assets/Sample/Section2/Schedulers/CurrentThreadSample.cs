using System.Threading;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Sample.Section2.Schedulers
{
    public class CurrentThreadSample : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log("Unity Main Thread ID:" + Thread.CurrentThread.ManagedThreadId);
            var subject = new Subject<Unit>();
            subject.AddTo(this);
            subject
                // OnNext 在当前线程执行
                .ObserveOn(Scheduler.Immediate)
                .Subscribe(_ =>
                {
                    Debug.Log("Thread Id:" + Thread.CurrentThread.ManagedThreadId);
                });
            // 在主线程 发行 OnNext消息
            subject.OnNext(Unit.Default);
            // 别的线程上发行OnNext消息  
            Task.Run(() => subject.OnNext(Unit.Default));
            subject.OnCompleted();
            
            
            /*
             *Unity Main Thread ID:1
             * Thread Id:1
             * Thread Id:79
             */
        }
    }
}