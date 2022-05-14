using System;
using UniRx;

namespace Sample.Section3.ReactiveProperty
{
    // Fruit Enum
    public enum Fruit
    {
        Apple,
        Banana,
        Peach,
        Melon,
        Orange
    }
    // Fruit 型的 ReactiveProperty
    [Serializable]
    public class FruitReactiveProperty : ReactiveProperty<Fruit>
    {
        public FruitReactiveProperty()
        {
        }
        public FruitReactiveProperty(Fruit init) : base(init)
        {
        }
    }
    
}