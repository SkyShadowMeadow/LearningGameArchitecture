using Assets.Scripts.Data;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.PersistentProgress;
using Assets.Scripts.Infrastructure.Services.SaveLoadService;
using Scripts.Infrasracture.States;
using System;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.States
{
    public class SaveLoadState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoad _saveLoadService;

        public SaveLoadState (GameStateMachine gameStateMachine, IPersistentProgressService progressService, ISaveLoad saveLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            LoadOrInitProgress();
            _gameStateMachine.Enter<LoadLevelState, string>(_progressService.Progress.WorldData.PositionOnLevel.LevelName);
        }

        public void Exit()
        {        }
        
        private void LoadOrInitProgress() =>
            _progressService.Progress =
               _saveLoadService.LoadProgress()
                ?? NewProgress();
        

        private PlayerProgress NewProgress() =>
            new PlayerProgress("Cemetery");
   
    }
}
