using UniRx;

namespace Sample.Section3.ReactiveProperty.Editor
{
    // 编辑器扩张
    [UnityEditor.CustomPropertyDrawer(typeof(FruitReactiveProperty))]
    public class ExtendInspectorDisplayDrawer : InspectorDisplayDrawer
    {
    }
}