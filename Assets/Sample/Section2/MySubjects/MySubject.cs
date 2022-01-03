using System;
using UniRx;
using System.Collections.Generic;

namespace Sample.Section2.MySubjects
{
    //简单的MySubject
    public class MySubject<T> : ISubject<T>,IDisposable
    {
        public bool IsStopped { get; } = false;
        public bool IsDisposed { get; } = false;

        private readonly object _lockObject = new object();
        
        //途中发生的异常
        private Exception _error;
        
        //登陆的 Observer List
        private List<IObserver<T>> _observers;

        public MySubject()
        {
            _observers = new List<IObserver<T>>();
        }
        //实现 IObserver.OnNext
        public void OnNext(T value)
        {
            if (IsStopped) return;
            lock (_lockObject)
            {
                ThrowIfDisposed();
                //把消息传给所有的observer
                foreach (var observer in _observers)
                {
                    observer.OnNext(value);
                }
            }
        }
        //实现Observer.OnError
        public void OnError(Exception error)
        {
            lock (_lockObject)
            {
                ThrowIfDisposed();
                if (IsStopped) return;
                this._error = error;

                try
                {
                    foreach (var observer in _observers)
                    {
                        observer.OnError(_error);
                    }
                }
                finally
                {
                    Dispose();
                }
            }
        }
     
        //实现Observer.OnCompleted
        public void OnCompleted()
        {
            lock (_lockObject)
            {
                ThrowIfDisposed();
                if (IsStopped) return;
                try
                {
                    foreach (var observer in _observers)
                    {
                        observer.OnCompleted();
                    }
                }
                finally
                {
                    Dispose();
                }
            }
        }
        //实现IObservable.Subscribe 
        public IDisposable Subscribe(IObserver<T> observer)
        {
            lock (_lockObject)
            {
                //如果已经结束 发行OnError 或者OnCompleted
                if (IsStopped)
                {
                    if (_error != null)
                    {
                        observer.OnError(_error);
                    }
                    else
                    {
                        observer.OnCompleted();
                    }

                    return Disposable.Empty;
                }
                _observers.Add(observer);//添加到List里
                return new Subscription(this, observer);
            }
        }
        
        private void ThrowIfDisposed()
        {
            if (IsDisposed)
                throw new ObjectDisposedException("MySubject");
        }

        public void Dispose()
        {
            lock (_lockObject)
            {
                if (!IsDisposed)
                {
                    _observers.Clear();
                    _observers = null;
                    _error = null;
                }
            }
        }
        //
        private sealed class Subscription : IDisposable
        {
            private readonly IObserver<T> _observer; 
            private readonly MySubject<T> _parent;
            public Subscription(MySubject<T> parent, IObserver<T> observer)
            {
                this._parent = parent;
                this._observer = observer;
            }
            public void Dispose() {
                // Dispose 的时候从 List里删除
                _parent._observers.Remove(_observer);
            }

        }
    }
}