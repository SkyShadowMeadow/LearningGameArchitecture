using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.CodeBase.Enemy
{
    class AgentMoveToPlayer : MonoBehaviour
    {
        private const float MinimalDistance = 1;

        public NavMeshAgent Agent;

        private Transform _heroTransform;
        private IGameFactory _gameFactory;

        private void Start()
        {
            _gameFactory = AllServices.Container.Single<IGameFactory>();

            if (_gameFactory.HeroGameObject != null)
                InitializeHeroTransform();
            else
                _gameFactory.HeroCreated += HeroCreated;
        }

        private void Update()
        {
            if (IsInitialized() && IsHeroNotReached())
                Agent.destination = _heroTransform.position;
        }

        private void OnDestroy()
        {
            if (_gameFactory != null)
                _gameFactory.HeroCreated -= HeroCreated;
        }

        private bool IsInitialized() =>
          _heroTransform != null;

        private void HeroCreated() =>
          InitializeHeroTransform();

        private void InitializeHeroTransform() =>
          _heroTransform = _gameFactory.HeroGameObject.transform;

        private bool IsHeroNotReached() =>
          Vector3.Distance(Agent.transform.position, _heroTransform.position) >= MinimalDistance;
    }
}

