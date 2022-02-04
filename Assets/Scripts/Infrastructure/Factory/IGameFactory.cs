using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.PersistentProgress;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Infrasracture.Factory
{
    public interface IGameFactory: IService
    {
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }

        GameObject CreateHero(GameObject at);
        void CreateHud();
        void CleanUp();

    }
}