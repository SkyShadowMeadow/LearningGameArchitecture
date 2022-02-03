using Assets.Scripts.Data;

namespace Assets.Scripts.Infrastructure.Services.PersistentProgress
{
    interface IPersistentProgressService : IService
    {
        PlayerProgress Progress { get; set; }
    }
}