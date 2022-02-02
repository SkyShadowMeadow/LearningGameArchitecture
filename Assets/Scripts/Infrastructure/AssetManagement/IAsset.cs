using Assets.Scripts.Infrastructure.Services;
using UnityEngine;

namespace Scripts.Infrasracture.AssetManagement
{
    public interface IAsset : IService
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 at);
    }
}