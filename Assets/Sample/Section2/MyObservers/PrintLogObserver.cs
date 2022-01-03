using System;

namespace Sample.Section2.MyObservers
{
    //继承IObserver<T> 用来打印消息的Observer
    public class PrintLogObserver<T> : IObserver<T>
    {
        public void OnCompleted()
        {
            UnityEngine.Debug.Log("OnCompleted");
        }

        public void OnError(Exception error)
        {
            UnityEngine.Debug.LogError(error);
        }

        public void OnNext(T value)
        {
            UnityEngine.Debug.Log(value);
        }
    }
}