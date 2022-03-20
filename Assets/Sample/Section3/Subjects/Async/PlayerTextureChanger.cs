using UniRx;
using UnityEngine;

namespace Sample.Section3.Subjects.Async
{
    //玩家图片变更
    public class PlayerTextureChanger : MonoBehaviour
    {
        [SerializeField]
        private GameResourceProvider _gameResourceProvider;
        private void Start()
        {
            // 当玩家图片加载完后再 设定玩家图片
            _gameResourceProvider.PlayerTextureAsync
                .Subscribe(SetMyTexture)
                .AddTo(this);
        }
        private void SetMyTexture(Texture newTexture)
        {
            var r = GetComponent<Renderer>();
            r.sharedMaterial.mainTexture = newTexture;
        }
    }
    
}