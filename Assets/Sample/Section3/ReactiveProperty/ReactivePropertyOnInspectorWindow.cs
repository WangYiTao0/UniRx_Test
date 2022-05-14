using UnityEngine;
using UniRx;

namespace Sample.Section3.ReactiveProperty
{
    public class ReactivePropertyOnInspectorWindow : MonoBehaviour
    {
        // 不会表示
        public ReactiveProperty<int> A;
        // 会表示
        public IntReactiveProperty B;
        
        //其他的各种类型
        public LongReactiveProperty C1;
        public ByteReactiveProperty C2;
        public FloatReactiveProperty C3;
        public DoubleReactiveProperty C4;
        public StringReactiveProperty C5;
        public BoolReactiveProperty C6;
        public Vector2ReactiveProperty C7;
        public Vector3ReactiveProperty C8;
        public Vector4ReactiveProperty C9;
        public ColorReactiveProperty C10;
        public RectReactiveProperty C11;
        public AnimationCurveReactiveProperty C12;
        public BoundsReactiveProperty C13;
        public QuaternionReactiveProperty C14;
        
    }
}