using System;
using UniRx;
using UnityEngine;

namespace Sample.Section3.FactoryMethods
{
    public class ObserveEveryValueChangedSample : MonoBehaviour
    {
        private void Start()
        {
            // 监视每帧的坐标 有变化发送消息
            transform.ObserveEveryValueChanged(x => x.position)
                .Subscribe(vec3 => Debug.Log("现在的坐标:" + vec3));
            var rigidBody = GetComponent<Rigidbody>();
            // 在FixedUpdate 监视 RigidBody 速度变化时通知
            // FrameCountType 
            rigidBody
                .ObserveEveryValueChanged(
                    x => x.velocity,
                    FrameCountType.FixedUpdate)
                .Subscribe(vec3 => Debug.Log("速度:" + vec3));
        }
    }
}