using Scripts.Infrasracture.States;
using Scripts.Logic;
using UnityEngine;

namespace Scripts.Infrasracture
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private LoadingCurtain LoadingCurtainPrefab;
        private Game _game;

        private void Awake()
        {
            _game = new Game(this, Instantiate(LoadingCurtainPrefab));
            _game.GameStateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }
}
