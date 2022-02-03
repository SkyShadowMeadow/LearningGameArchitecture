using Assets.Scripts.Data;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.PersistentProgress;
using Scripts.Services.Input;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Hero
{
    public class Move : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _movementSpeed;
        private IInputService _inputService;
        private Camera _camera;

        private void Awake()
        {
            _inputService = AllServices.Container.GetSingle<IInputService>();
        }

        void Start()
        {
            _camera = Camera.main;
        }

        void Update()
        {
            Vector3 movementVector = Vector3.zero;
            if (_inputService.Axes.sqrMagnitude > Constants.Epsilon)
            {
                movementVector = _camera.transform.TransformDirection(_inputService.Axes);
                movementVector.y = 0;
                movementVector.Normalize();

                transform.forward = movementVector;
            }
            movementVector += Physics.gravity;

            _characterController.Move(movementVector * _movementSpeed * Time.deltaTime);
        }

        public void LoadProgress(PlayerProgress playerProgress)
        {
            if(GetCurrentScene() == playerProgress.WorldData.PositionOnLevel.LevelName)
            {
                Vector3Data savedPosition = playerProgress.WorldData.PositionOnLevel.Position;
                if (savedPosition != null)
                    Wrap(to: savedPosition);
                transform.position = playerProgress.WorldData.PositionOnLevel.Position.TurnToVector3Unity();
            }
        }

        private void Wrap(Vector3Data to)
        {
            _characterController.enabled = false;
            transform.position = to.TurnToVector3Unity();
            _characterController.enabled = true;
        }

        public void UpdateProgress(PlayerProgress playerProgress)
        {
            playerProgress.WorldData.PositionOnLevel = new PositionOnLevel(GetCurrentScene(), transform.position.TurnToVector3Data());
        }

        private static string GetCurrentScene() =>
            SceneManager.GetActiveScene().name;
    }
}
