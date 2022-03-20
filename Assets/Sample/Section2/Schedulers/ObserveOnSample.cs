using System.IO;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Sample.Section2.Schedulers
{
    public class ObserveOnSample : MonoBehaviour
    {
        
        private void Start()
        {
            //在线程池上读取文件
            var task = Task.Run(() => File.ReadAllText(@"data.txt"));
            // Task -> Observable 变换
            // 这时候线程不变
            task.ToObservable()
                // 这时候切换线程 到 主线程
                .ObserveOn(Scheduler.MainThread)
                .Subscribe(x =>
         
                {
                    // 到这时线程已经切换
                    Debug.Log(x);
                });
        }
        
    }
}