using Assets.Scripts.Infrastructure.Services;
using Scripts.Infrasracture.States;
using Scripts.Logic;

namespace Scripts.Infrasracture
{
    public class Game
    {
        public GameStateMachine GameStateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain)
        {
            GameStateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), loadingCurtain, AllServices.Container);
        }
    }
}