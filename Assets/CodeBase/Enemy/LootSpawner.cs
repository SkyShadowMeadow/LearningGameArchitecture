﻿using Assets.CodeBase.Data;
using Assets.CodeBase.Infrastructure.Services.Randomizer;
using Assets.CodeBase.Logic;
using CodeBase.Infrastructure.Factory;
using UnityEngine;

namespace Assets.CodeBase.Enemy
{
    public class LootSpawner : MonoBehaviour
    {
        public EnemyDeath EnemyDeath;

        private IGameFactory _factory;
        private IRandomService _randomizer;

        private int _minValue;
        private int _maxValue;

        public void Construct(IGameFactory factory, IRandomService randomService)
        {
            _factory = factory;
            _randomizer = randomService;
        }

        private void Start()
        {
            EnemyDeath.Happened += SpawnLoot;
        }

        public void SetLootValue(int min, int max)
        {
            _minValue = min;
            _maxValue = max;
        }

        private void SpawnLoot()
        {
            EnemyDeath.Happened -= SpawnLoot;

            LootPiece lootPiece = _factory.CreateLoot();
            lootPiece.transform.position = transform.position;
            lootPiece.GetComponent<UniqueId>().GenerateId();

            Loot loot = GenerateLoot();

            lootPiece.Initialize(loot);
        }

        private Loot GenerateLoot()
        {
            Loot loot = new Loot()
            {
                Value = _randomizer.Next(_minValue, _maxValue)
            };
            return loot;
        }
    }
}
