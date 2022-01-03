using System;
using UnityEngine;
using UniRx;

namespace Sample.Section2.MyObservers
{
    public class ObserveEventComponent2 : MonoBehaviour
    {
        [SerializeField]
        private CountDownEventProvider _countDownEventProvider;
        private PrintLogObserver<int> _printLogObserver;
        private IDisposable _disposable;

        private void Start()
        {
            _disposable = _countDownEventProvider
                .CountDownObservable
                .Subscribe(
                    x => Debug.Log(x), // OnNext
                    ex => Debug.LogError(ex), // OnError
                    () => Debug.Log("OnCompleted!")); // OnCompleted
        }
        private void OnDestroy() 
        {
            _disposable?.Dispose();
        }
    }
}