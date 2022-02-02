using UnityEngine;

namespace Scripts.Infrasracture.AssetManagement
{
    public interface IAssetProvider
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 at);
    }
}