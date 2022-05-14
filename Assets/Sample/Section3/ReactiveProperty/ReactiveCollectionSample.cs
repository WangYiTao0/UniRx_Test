using UniRx;
using UnityEngine;

namespace Sample.Section3.ReactiveProperty
{
    public class ReactiveCollectionSample : MonoBehaviour
    {
        private void Start()
        {
            var rc = new ReactiveCollection<int>();
            
            //订阅 要素增加的消息 
            rc.ObserveAdd()
                .Subscribe((CollectionAddEvent<int> a) =>
                {
                    Debug.Log($"Add [{a.Index}]:{a.Value}");
                });
            //订阅 要素删除的消息 
            rc.ObserveRemove()
                .Subscribe((CollectionRemoveEvent<int> r) =>
                {
                    Debug.Log($"Remove [{r.Index}]:{r.Value}");
                });
            // 订阅 要素更新 的消息
            rc.ObserveReplace()
                .Subscribe((CollectionReplaceEvent<int> r) =>
                {
                    Debug.Log($"Replace [{r.Index}]:{r.OldValue} -> {r.NewValue}");
                });

            // 订阅 要素个数更新 的消息
            rc.ObserveCountChanged()
                .Subscribe((int c) =>
                {
                    Debug.Log($"Count: {c}");
                });

            // 订阅 要素的Index 变更的消息
            rc.ObserveMove()
                .Subscribe((CollectionMoveEvent<int> x) =>
                {
                    Debug.Log($"Move {x.Value}:[{x.OldIndex}] -> [{x.NewIndex}]");
                });
   
            rc.Add(1);
            rc.Add(2);
            rc.Add(3);
            rc[1] = 5;
            rc.RemoveAt(0);
            // Dispose() 时候向 Observable 发送 OnCompleted的消息  
            rc.Dispose();
        }
    }
}