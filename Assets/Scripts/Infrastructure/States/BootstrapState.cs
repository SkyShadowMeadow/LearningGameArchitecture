using Assets.Scripts.Infrastructure.Services;
using Scripts.Infrasracture.AssetManagement;
using Scripts.Infrasracture.Factory;
using Scripts.Services.Input;
using System;
using UnityEngine;

namespace Scripts.Infrasracture.States
{
    public class BootstrapState : IState
    {
        private const string EntryScene = "EntryScene";
        private GameStateMachine _gameStateMachine;
        private SceneLoader _sceneLoader;
        private readonly AllServices _services;


        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _services = services;

            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(EntryScene, onLoaded: EntryLoadLevel);
        }
        public void Exit()
        { }

        private void EntryLoadLevel() => 
            _gameStateMachine.Enter<LoadLevelState, string>("Cemetery");

        private void RegisterServices()
        {
            _services.RegisterSingle<IAsset>(new AssetProvider());
            _services.RegisterSingle<IInputService>(RegisterInputService());
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.GetSingle<IAsset>()));
        }
        private static InputService RegisterInputService()
        {
            if (Application.isEditor)
                return new StandaloneInputService();
            else
                return new MobileInputService();
        }

    }
}
