using Scripts.Services.Input;
using UnityEngine;

namespace Scripts.Infrasracture
{
    public class BootstrapState : IState
    {
        private GameStateMachine _gameStateMachine;

        public BootstrapState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        public void Enter()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
            Game.InputService = RegisterInputService();
        }
        private static InputService RegisterInputService()
        {
            if (Application.isEditor)
                return new StandaloneInputService();
            else
                return new MobileInputService();
        }
        public void Exit()
        {
        }
    }
}
