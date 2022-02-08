﻿using Assets.CodeBase.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.CodeBase.UI
{
    public class ActorUI : MonoBehaviour
    {
        public HpBar HpBar;

        private HeroHealth _health;

        public void Construct(HeroHealth health)
        {
            _health = health;
            _health.HealthChanged += UpdateHpBar;
        }

        private void Start()
        {
            HeroHealth health = GetComponent<HeroHealth>();

            if (health != null)
                Construct(health);
        }

        private void OnDestroy()
        {
            _health.HealthChanged -= UpdateHpBar;
        }

        private void UpdateHpBar()
        {
            HpBar.SetValue(_health.Current, _health.Max);
        }

    }
}
