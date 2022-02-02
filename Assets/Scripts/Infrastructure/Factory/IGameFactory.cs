using Assets.Scripts.Infrastructure.Services;
using UnityEngine;

namespace Scripts.Infrasracture.Factory
{
    public interface IGameFactory: IService
    {
        GameObject CreateHero(GameObject at);
        void CreateHud();
    }
}