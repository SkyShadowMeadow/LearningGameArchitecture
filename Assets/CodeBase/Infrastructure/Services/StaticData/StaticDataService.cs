using Assets.CodeBase.StaticData;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string MonstersDataPath = "StaticData/Monsters";
        private Dictionary<MonsterTypeId, MonsterStaticData> _monsters;

        public void LoadMonsters()
        {
            _monsters = Resources
              .LoadAll<MonsterStaticData>(MonstersDataPath)
              .ToDictionary(x => x.MonsterTypeId, x => x);
        }

        public MonsterStaticData ForMonster(MonsterTypeId typeId) =>
          _monsters.TryGetValue(typeId, out MonsterStaticData staticData)
            ? staticData
            : null;
    }
}
