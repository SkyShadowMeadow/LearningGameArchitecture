using Scripts.Services.Input;
using System;
using UnityEngine;

namespace Scripts.Infrasracture
{
    public class BootstrapState : IState
    {
        private const string EntryScene = "EntryScene";
        private GameStateMachine _gameStateMachine;
        private SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }
        public void Enter()
        {
            RegisterServices();
            _sceneLoader.Load(EntryScene, onLoaded: EntryLoadLevel);
        }

        private void EntryLoadLevel() => _gameStateMachine.Enter<LoadLevelState, string>("Cemetery");

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
