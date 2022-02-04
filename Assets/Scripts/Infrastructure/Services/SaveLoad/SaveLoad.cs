using Assets.Scripts.Data;
using Assets.Scripts.Infrastructure.Services.PersistentProgress;
using Scripts.Infrasracture.Factory;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.SaveLoadService
{
    public class SaveLoad : ISaveLoad
    {
        private const string ProgressKey = "Progress";

        private readonly IPersistentProgressService _progressService;
        private readonly IGameFactory _gameFactory;

        public SaveLoad(IPersistentProgressService progress, IGameFactory gameFactory)
        {
            _progressService = progress;
            _gameFactory = gameFactory;
        }
        public PlayerProgress LoadProgress() =>
            PlayerPrefs.GetString(ProgressKey)?.ToDeserialized<PlayerProgress>();

        public void SaveProgress()
        {
            foreach (ISavedProgress writer in _gameFactory.ProgressWriters)
            {
                writer.UpdateProgress(_progressService.Progress);
            }

            PlayerPrefs.SetString(ProgressKey, _progressService.Progress.ToJson());
        }
    }
}
