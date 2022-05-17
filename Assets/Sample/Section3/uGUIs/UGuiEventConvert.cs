using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Sample.Section3.uGUIs
{
    public class UGuiEventConvert : MonoBehaviour
    {
        [SerializeField] private Toggle _uiToggle;

        private void Start()
        {
            _uiToggle.isOn = false;
            // uGUI AsObservable 变换
            _uiToggle.onValueChanged.AsObservable()
                .Subscribe(x => Debug.Log("当前的状态(AsObservable):" + x));
      
            // Subscribe 时 自动发行初期值
            _uiToggle.OnValueChangedAsObservable()
                .Subscribe(x => Debug.Log("当前的状态(扩张方法):" + x));
            Debug.Log("---");
            _uiToggle.isOn = true;
        }
    }
}