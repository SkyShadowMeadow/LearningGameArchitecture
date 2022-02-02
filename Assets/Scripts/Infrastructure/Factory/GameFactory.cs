
using Scripts.Infrasracture.AssetManagement;
using UnityEngine;

namespace Scripts.Infrasracture.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAsset _assets;

        public GameFactory(IAsset assets)
        {
            _assets = assets;
        }

        public GameObject CreateHero(GameObject at) 
            => _assets.Instantiate(AssetPath.HeroPath, at.transform.position);

        public void CreateHud() 
            => _assets.Instantiate(AssetPath.HudPath);

    }
}
