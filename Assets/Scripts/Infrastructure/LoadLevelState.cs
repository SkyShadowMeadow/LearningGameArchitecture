//using System;
using Scripts.CameraLogic;
using Scripts.Logic;
using UnityEngine;

namespace Scripts.Infrasracture
{
    public class LoadLevelState : IPayLoadState<string>
    {
        private const string InitialPointTag = "InitialPoint";

        private GameStateMachine _gameStateMachine;
        private SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
        }

        public void Enter(string sceneLevel)
        {
            _loadingCurtain.Show();
            _sceneLoader.Load(sceneLevel, OnLoaded);
        }

        public void Exit() =>
            _loadingCurtain.Hide();
        
        private void OnLoaded()
        {
            GameObject hero = _gameFactory.CreateHero(at: GameObject.FindGameObjectWithTag(InitialPointTag));
            _gameFactory.CreateHud();
            SetCameraToFollow(hero);

            _gameStateMachine.Enter<GameLoopState>();
        }

        private static void SetCameraToFollow(GameObject hero)
        {
            Camera.main
                .GetComponent<CameraFollow>()
                .SetWhatToFollow(hero);
        }
    }
}
