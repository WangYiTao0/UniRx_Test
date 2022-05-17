using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Sample.Section3.FactoryMethods
{
    public class TriggerSample : MonoBehaviour
    {
        [SerializeField] private GameObject _childGameObject;

        private void Start()
        {
            // 添加 UniRx.Triggers 
            // 把 Unity Event 作为  Observable 来使用
            // 把这个的GameObject 的Update 变为 Observable
            this.UpdateAsObservable()
                .Subscribe(_ =>
                {
                    transform.position += Vector3.forward * Time.deltaTime;
                });
            // 把其他的GameObject 的OnCollisionEnter 变为Observable 
            _childGameObject.OnCollisionEnterAsObservable()
                .Subscribe(collision =>
                {
                    Debug.Log(collision.gameObject.name + "OnCollisionEnter");
                }).AddTo(this); // 因为调用了其他的GameObject。使用AddTo会比较安全

            // 这个的GameObject 的OnDestroy 变为 Observable
            this.OnDestroyAsObservable()
                .Subscribe(_ =>
                {
                    Debug.Log("OnDestroy");
                });
        }
    }
}