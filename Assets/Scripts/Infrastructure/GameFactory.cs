
using Scripts.Infrasracture.AssetManagement;
using UnityEngine;

namespace Scripts.Infrasracture
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assets;

        public GameFactory(IAssetProvider assets)
        {
            _assets = assets;
        }

        public GameObject CreateHero(GameObject at) 
            => _assets.Instantiate(AssetPath.HeroPath, at.transform.position);

        public void CreateHud() 
            => _assets.Instantiate(AssetPath.HudPath);

    }
}
