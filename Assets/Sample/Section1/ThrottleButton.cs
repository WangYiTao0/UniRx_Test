using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Sample.Section1
{
    public class ThrottleButton : MonoBehaviour
    {
        private Subject<int> asd;
        private void Start()
        {
            //Update()每一帧对Fire Btn 有没有被按下进行判定
            //按下了就调用Subscribe对处理
            //然后无视30帧
            this.UpdateAsObservable()
                .Where(_ => Input.GetButtonDown("Fire1"))
                .ThrottleFirstFrame(30)
                .Subscribe(_ =>
                {
                    Debug.Log("Fire");
                });
        }
    }
}