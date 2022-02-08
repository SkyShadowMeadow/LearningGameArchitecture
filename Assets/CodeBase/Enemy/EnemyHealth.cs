using Assets.CodeBase.Logic;
using CodeBase.Enemy;
using System;
using UnityEngine;

namespace Assets.CodeBase.Enemy
{
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        public EnemyAnimator Animator;

        [SerializeField]
        private float _current;

        [SerializeField]
        private float _max;

        public event Action HealthChanged;

        public float Current
        {
            get => _current;
            set => _current = value;
        }

        public float Max
        {
            get => _max;
            set => _max = value;
        }

        public void TakeDamage(float damage)
        {
            Current -= damage;

            Animator.PlayHit();

            HealthChanged?.Invoke();
        }

    }
}
