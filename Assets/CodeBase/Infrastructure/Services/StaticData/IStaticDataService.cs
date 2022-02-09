using Assets.CodeBase.StaticData;
using CodeBase.Infrastructure.Services;

namespace Assets.CodeBase.Infrastructure.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        void LoadMonsters();
        MonsterStaticData ForMonster(MonsterTypeId typeId);
    }
}
