using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.SaveLoadService;
using UnityEngine;

namespace Assets.Scripts.Logic
{
    public class SaveTrigger : MonoBehaviour
    {
        private ISaveLoad _saveLoad;
        [SerializeField] private BoxCollider _collider;

        private void Awake() =>
            _saveLoad = AllServices.Container.GetSingle<ISaveLoad>();

        private void OnTriggerEnter(Collider other)
        {
            _saveLoad.SaveProgress();
            Debug.Log("Save progress");
            gameObject.SetActive(false);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color32(30, 200, 30, 130);
            Gizmos.DrawCube(transform.position + _collider.center, _collider.size);
        }
    }
}
