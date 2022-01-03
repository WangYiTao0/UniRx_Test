using System;
using System.Collections;
using UniRx;
using UnityEngine;

namespace Sample.Section2.MyObservers
{
    //指定倒计时 事件通知
    public class CountDownEventProvider : MonoBehaviour
    {
        [SerializeField] private int _countSeconds = 10;

        //Subject 
        private Subject<int> _subject;
        
        //只公开 Subject 的IObservable的接口
        public IObservable<int> CountDownObservable => _subject;

        private void Awake()
        {
            //Subject 生成
            _subject = new Subject<int>();
            
            //开启 倒计时协程
            StartCoroutine(CountCoroutine());
        }

        private IEnumerator CountCoroutine()
        {
            var current = _countSeconds;

            while (current > 0)
            {
                //发行现在的值
                _subject.OnNext(current);
                current--;
                yield return new WaitForSeconds(1f);
            }
            //最后发行 0 和 OnComplete
            _subject.OnNext(0);
            _subject.OnCompleted();
        }

        private void OnDestroy()
        {
            //当GameObject销毁是 释放Subject
            _subject.Dispose();
        }
    }
}