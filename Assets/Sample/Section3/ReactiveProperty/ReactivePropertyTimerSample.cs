using System.Collections;
using UniRx;
using UnityEngine;

namespace Sample.Section3.ReactiveProperty
{
    //倒计时
    public class ReactivePropertyTimerSample : MonoBehaviour
    {
        // 定义 ReactiveProperty 
        [SerializeField]
        private IntReactiveProperty _current = new IntReactiveProperty(60);
        // 现在的倒计时的时间 （读取专用）
        // ReactiveProperty 转换成 IReadOnlyReactiveProperty
        public IReadOnlyReactiveProperty<int> CurrentTime => _current;
        
        private void Start()
        {
            StartCoroutine(CountDownCoroutine());
            _current
                .Subscribe(_x =>
                {
                    Debug.Log($"倒计时 {_x}");
                }).AddTo(this);
        }
        private IEnumerator CountDownCoroutine()
        {
            while (_current.Value > 0)
            {
                // 1秒 更新 1此
                _current.Value--;
                yield return new WaitForSeconds(1);
            }
        }
    }
}