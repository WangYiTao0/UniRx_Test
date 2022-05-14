using System;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;

namespace Sample.Section3.ReactiveProperty
{
    public class ReactiveDictionarySample : MonoBehaviour
    {
        private void Start()
        {
                var rd = new ReactiveDictionary<string, string>();
                // 订阅 要素添加的消息
                rd.ObserveAdd()
                    .Subscribe((DictionaryAddEvent<string, string> a) =>
                    {
                        Debug.Log($"[{a.Key}]里添加{a.Value}");
                    });
                // 订阅 要素消除的消息
                rd.ObserveRemove()
                    .Subscribe((DictionaryRemoveEvent<string, string> r) =>
                    {
                        Debug.Log($"[{r.Key}]里消除{r.Value}");
                    });
                // 订阅 要素更新的消息
                rd.ObserveReplace()
                    .Subscribe((DictionaryReplaceEvent<string, string> r) =>
                    {
                        Debug.Log($"[{r.Key}]的{r.OldValue}更新成{r.NewValue}");
                    });
                // 订阅 要素总数更新的消息
                rd.ObserveCountChanged()
                    .Subscribe((int c) =>
                    {
                        Debug.Log("要素总数" + c);
                    });
                // Add
                rd["Apple"] = "苹果";
                rd["Banana"] = "香蕉";
                rd["Lemon"] = "柠檬";
                // Replace
                rd["Apple"] = "红苹果";
                // Remove
                rd.Remove("Banana");
                // Dispose() 时候向 Observable 发送 OnCompleted的消息  
                rd.Dispose();
        }
    }
}