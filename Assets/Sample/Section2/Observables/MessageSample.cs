using System;
using UniRx;
using UnityEngine;

namespace Sample.Section2.Observables
{
    public class MessageSample : MonoBehaviour
    {
        //剩余时间
        [SerializeField] private float _countTimeSeconds = 30f;

        //到时间 进行通知的Observable
        public IObservable<Unit> OnTimeUpAsyncSubject => _onTimeUpAsyncSubject;
        //AsyncSubject (只发行一次消息的Subject)
        private readonly AsyncSubject<Unit> _onTimeUpAsyncSubject = new AsyncSubject<Unit>();

        private IDisposable _disposable;

        private void Start()
        {
            //经过指定时间 发送消息
            _disposable = Observable
                .Timer(TimeSpan.FromSeconds(_countTimeSeconds))
                .Subscribe(_ =>
                {
                    //当 Timer 到了
                    //发送Unit型的消息
                    
                    _onTimeUpAsyncSubject.OnNext(Unit.Default);
                    _onTimeUpAsyncSubject.OnCompleted();
                });
        }

        private void OnDestroy()
        {
            //Observable 如果还在运作 停止
            _disposable?.Dispose();
            //Destory AsyncSubject
            _onTimeUpAsyncSubject.Dispose();
        }
    }
}