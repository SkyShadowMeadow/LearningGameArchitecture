
using Assets.Scripts.Infrastructure.Services.PersistentProgress;
using Scripts.Infrasracture.AssetManagement;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Infrasracture.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAsset _assets;
        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();

        public GameFactory(IAsset assets)
        {
            _assets = assets;
        }

        public GameObject CreateHero(GameObject at) =>
            InstatiateRegistered(AssetPath.HeroPath, at.transform.position);

        public void CreateHud()
            => InstatiateRegistered(AssetPath.HudPath);

        private GameObject InstatiateRegistered(string prefabPath, Vector3 at)
        {
            GameObject gameObject = _assets.Instantiate(prefabPath, at);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }
        private GameObject InstatiateRegistered(string prefabPath)
        {
            GameObject gameObject = _assets.Instantiate(prefabPath);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }

        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (ISavedProgressReader progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
            {
                Register(progressReader);
            }
        }
        private void Register(ISavedProgressReader progressReader)
        {
            if (progressReader is ISavedProgress progressWriter)
                ProgressWriters.Add(progressWriter);
            ProgressReaders.Add(progressReader);
        }

        public void CleanUp()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }

    }
}
