using UnityEngine;

namespace Scripts.Infrasracture
{
    public class GameRunner : MonoBehaviour
    {
        [SerializeField] private GameBootstrapper bootstrapperPrefab;

        private void Awake()
        {
            bootstrapperPrefab = FindObjectOfType<GameBootstrapper>();
            if (bootstrapperPrefab == null)
                Instantiate(bootstrapperPrefab);
        }
    }
}
