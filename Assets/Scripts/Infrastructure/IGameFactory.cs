using UnityEngine;

namespace Scripts.Infrasracture
{
    public interface IGameFactory
    {
        GameObject CreateHero(GameObject at);
        void CreateHud();
    }
}