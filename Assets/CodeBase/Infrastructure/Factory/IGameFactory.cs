using System;
using System.Collections.Generic;
using Assets.CodeBase.StaticData;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateHero(GameObject at);
        GameObject CreateHud();
        GameObject CreateMonster(MonsterTypeId typeId, Transform parent);
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }
        void Cleanup();
        void Register(ISavedProgressReader savedProgress);
    }
}