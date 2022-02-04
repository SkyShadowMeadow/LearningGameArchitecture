using Assets.Scripts.Data;

namespace Assets.Scripts.Infrastructure.Services.SaveLoadService
{
    public interface ISaveLoad : IService
    {
        PlayerProgress LoadProgress();
        void SaveProgress();
    }
}
