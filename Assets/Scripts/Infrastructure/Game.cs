using Scripts.Services.Input;
using UnityEngine;

namespace Scripts.Infrasracture
{
    public class Game
    {
        public static IInputService InputService;
        public GameStateMachine GameStateMachine;

        public Game()
        {
            GameStateMachine = new GameStateMachine();
        }
    }
}