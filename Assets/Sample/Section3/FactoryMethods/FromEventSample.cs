using System;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Sample.Section3.FactoryMethods
{
    public class FromEventSample : MonoBehaviour
    {
        // 原始时间
        public sealed class MyEventArgs : EventArgs
        {
            public int MyProperty { get; set; }
        }
        
        // MyEventArgs Handler
        event EventHandler<MyEventArgs> _onEvent;
        // Int Action
        event Action<int> _callBackAction;
        
        // uGUI Button
        [SerializeField] private Button _uiButton;
        
        private readonly CompositeDisposable _disposables = new CompositeDisposable();
        private void Start()
        {
            // FromEventPattern 
            // (sender, eventArgs)を両方使ってイベントをIObservable<MyEventArgs>に変換する
            Observable.FromEventPattern<EventHandler<MyEventArgs>, MyEventArgs>(
                    h => h.Invoke,
                    h => _onEvent += h,
                    h => _onEvent -= h)
                .Subscribe()
                .AddTo(_disposables);
            // FromEvent 
            // eventArgs  => IObservable<MyEventArgs>
            Observable.FromEvent<EventHandler<MyEventArgs>, MyEventArgs>(
                    h => (sender, e) => h(e),
                    h => _onEvent += h,
                    h => _onEvent -= h)
                .Subscribe()
                .AddTo(_disposables);
            // Action<T> => Observable<T>
            Observable.FromEvent<int>(
                    h => _callBackAction += h, 
                    h => _callBackAction -= h)
                .Subscribe()
                .AddTo(_disposables);
            // UnityEvent => Observable 
            Observable.FromEvent<UnityAction>(
                    h => new UnityAction(h),
                    h => _uiButton.onClick.AddListener(h),
                    h => _uiButton.onClick.RemoveListener(h)
                ).Subscribe()
                .AddTo(_disposables);
            // UnityEvent 变换成 Observable 的简单语法
            _uiButton.onClick.AsObservable().Subscribe().AddTo(_disposables);
        }
        
        private void OnDestroy()
        {
            // 销毁的时候 Dispose
            _disposables.Dispose();
        }
    }
}