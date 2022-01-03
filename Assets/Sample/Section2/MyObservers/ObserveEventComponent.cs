using System;
using UnityEngine;

namespace Sample.Section2.MyObservers
{
    public class ObserveEventComponent : MonoBehaviour
    {
        [SerializeField] private CountDownEventProvider _countDownEventProvider;
        //Observer 
        private PrintLogObserver<int> _printLogObserver;
        private IDisposable _disposable;

        private void Start()
        {
            //PrintLogObserver 
            _printLogObserver = new PrintLogObserver<int>();

            //调用 Subject 的 Subscribe ，登陆 observer
            _disposable = _countDownEventProvider
                .CountDownObservable
                .Subscribe(_printLogObserver);
        }

        private void OnDestroy()
        {
            //GameObject 销毁时 注销事件
            _disposable?.Dispose();
        }
    }
}