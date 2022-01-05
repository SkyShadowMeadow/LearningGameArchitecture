//using System;
using Scripts.CameraLogic;
using Scripts.Logic;
using UnityEngine;

namespace Scripts.Infrasracture
{
    public class LoadLevelState : IPayLoadState<string>
    {
        private const string InitialPointTag = "InitialPoint";
        private const string HeroPath = "Hero/hero";
        private const string HudPath = "Hud/Hud";
        private GameStateMachine _gameStateMachine;
        private SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;

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

        public void Exit()
        {
            _loadingCurtain.Hide();
        }
        private void OnLoaded()
        {
            var initialPoint = GameObject.FindGameObjectWithTag(InitialPointTag);
            var hero = Instantiate(HeroPath, at: initialPoint.transform.position);
            Instantiate(HudPath);

            SetCameraToFollow(hero);

            _gameStateMachine.Enter<GameLoopState>();
        }

        private static GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }
        private static GameObject Instantiate(string path, Vector3 at)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }

        private static void SetCameraToFollow(GameObject hero)
        {
            Camera.main
                .GetComponent<CameraFollow>()
                .SetWhatToFollow(hero);
        }
    }
}
