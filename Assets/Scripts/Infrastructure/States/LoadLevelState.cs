//using System;
using Assets.Scripts.Infrastructure.Services.PersistentProgress;
using Scripts.CameraLogic;
using Scripts.Infrasracture.Factory;
using Scripts.Logic;
using System;
using UnityEngine;

namespace Scripts.Infrasracture.States
{
    public class LoadLevelState : IPayLoadState<string>
    {
        private const string InitialPointTag = "InitialPoint";

        private GameStateMachine _gameStateMachine;
        private SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _progressService;


        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain, IGameFactory gameFactory, IPersistentProgressService progressService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
            _progressService = progressService;
        }

        public void Enter(string sceneLevel)
        {
            _loadingCurtain.Show();
            _gameFactory.CleanUp();
            _sceneLoader.Load(sceneLevel, OnLoaded);
        }

        public void Exit() =>
            _loadingCurtain.Hide();
        
        private void OnLoaded()
        {
            InitGameWorld();
            InformProgressReaders();

            _gameStateMachine.Enter<GameLoopState>();
        }

        private void InitGameWorld()
        {
            GameObject hero = _gameFactory.CreateHero(at: GameObject.FindGameObjectWithTag(InitialPointTag));
            _gameFactory.CreateHud();
            SetCameraToFollow(hero);
        }
        private void InformProgressReaders()
        {
            foreach (ISavedProgress reader in _gameFactory.ProgressReaders)
                reader.LoadProgress(_progressService.Progress);
        }


        private static void SetCameraToFollow(GameObject hero)
        {
            Camera.main
                .GetComponent<CameraFollow>()
                .SetWhatToFollow(hero);
        }
    }
}
