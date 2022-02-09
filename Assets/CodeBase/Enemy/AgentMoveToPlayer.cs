using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.CodeBase.Enemy
{
    public class AgentMoveToPlayer : Follow
    {
        public NavMeshAgent Agent;

        private const float MinimalDistance = 1;

        private IGameFactory _gameFactory;
        private Transform _heroTransform;

        public void Construct(Transform heroTransform) =>
          _heroTransform = heroTransform;

        private void Update()
        {
            if (_heroTransform && IsHeroNotReached())
                Agent.destination = _heroTransform.position;
        }

        private bool IsHeroNotReached() =>
          Vector3.Distance(Agent.transform.position, _heroTransform.position) >= MinimalDistance;
    }
}

