using Assets.CodeBase.Enemy;
using Assets.CodeBase.StaticData;
using CodeBase.Data;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace Assets.CodeBase.Logic
{
    public class EnemySpawner : MonoBehaviour, ISavedProgress
    {
        public MonsterTypeId MonsterTypeId;

        private IGameFactory _factory;
        private EnemyDeath _enemyDeath;

        private string _id;
        private bool _slain;

        private void Awake()
        {
            _id = GetComponent<UniqueId>().Id;
            _factory = AllServices.Container.Single<IGameFactory>();
        }

        private void OnDestroy()
        {
            if (_enemyDeath != null)
                _enemyDeath.Happened -= Slay;
        }


        public void LoadProgress(PlayerProgress progress)
        {
            if (progress.KillData.ClearedSpawners.Contains(_id))
                _slain = true;
            else
                Spawn();
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            if (_slain)
                progress.KillData.ClearedSpawners.Add(_id);
        }

        private void Spawn()
        {
            GameObject monster = _factory.CreateMonster(MonsterTypeId, transform);
            _enemyDeath = monster.GetComponent<EnemyDeath>();
            _enemyDeath.Happened += Slay;
        }

        private void Slay()
        {
            if (_enemyDeath != null)
                _enemyDeath.Happened -= Slay;

            _slain = true;
        }
    }
}
