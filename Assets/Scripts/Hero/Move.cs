using Assets.Scripts.Infrastructure.Services;
using Scripts.CameraLogic;
using Scripts.Infrasracture;
using Scripts.Services.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Hero
{
    public class Move : MonoBehaviour
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
    }
}
