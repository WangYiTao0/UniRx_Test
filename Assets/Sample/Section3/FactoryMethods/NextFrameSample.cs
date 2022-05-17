using UniRx;
using UnityEngine;

namespace Sample.Section3.FactoryMethods
{
    public class NextFrameSample : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        private void Update()
        {
            //按下空格，添加RigidBody
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // 在下一个FixedUpdate 执行
                Observable.NextFrame(FrameCountType.FixedUpdate)
                    .Subscribe(_ =>
                    {
                        _rigidbody.AddForce(Vector3.up, ForceMode.VelocityChange);
                    });
            }
        }
    }
}