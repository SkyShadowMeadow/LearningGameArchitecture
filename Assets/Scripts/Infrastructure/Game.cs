using Scripts.Logic;
using Scripts.Services.Input;

namespace Scripts.Infrasracture
{
    public class Game
    {
        public static IInputService InputService;
        public GameStateMachine GameStateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain)
        {
            GameStateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), loadingCurtain);
        }
    }
}