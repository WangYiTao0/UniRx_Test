using System;
using UniRx;
using UnityEngine;

namespace Sample.Section2.Operators
{
    //对消息进行过滤
    public class OperatorTest : MonoBehaviour
    {
        private void Start()
        {
            var subject = new Subject<int>();

            //直接订阅
            subject.Subscribe(x => Debug.Log("raw: " + x));

            //过滤 0以下的数
            subject
                .Where(x => x > 0)
                .Subscribe(x => Debug.Log("filter: " + x));
            
            // 发行消息
            subject.OnNext(1); 
            subject.OnNext(-1); 
            subject.OnNext(3); 
            subject.OnNext(0);
            // 结束
            subject.OnCompleted(); 
            subject.Dispose();
        }
    }
}