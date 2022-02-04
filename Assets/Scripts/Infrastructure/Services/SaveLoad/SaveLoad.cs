using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.SaveLoadService
{
    public class SaveLoad : ISaveLoad
    {
        private const string ProgressKey = "Progress";

        public PlayerProgress LoadProgress() =>
            PlayerPrefs.GetString(ProgressKey)?.ToDeserialized<PlayerProgress>();

        public void SaveProgress()
        {
        }
    }
}
