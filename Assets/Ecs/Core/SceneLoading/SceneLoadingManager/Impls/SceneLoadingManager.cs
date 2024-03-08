using Core.LoadingProcessor.Impls;
using Ecs.Core.SceneLoading.LoadingProcessor.Impls;
using Game.Services.LevelService;
using UnityEngine.SceneManagement;
using Zenject;

namespace Ecs.Core.SceneLoading.SceneLoadingManager.Impls
{
    public class SceneLoadingManager : ISceneLoadingManager
    {
        private readonly SignalBus _signalBus;
        private LoadingProcessor.Impls.LoadingProcessor _processor;
        private readonly ILevelService _levelService;
        private string _lastScene;

        public SceneLoadingManager(
            SignalBus signalBus,
            ILevelService levelService
        )
        {
            _signalBus = signalBus;
            _levelService = levelService;
        }

        public void LoadGameLevel(string levelName)
        {
            _processor = new LoadingProcessor.Impls.LoadingProcessor();
            _processor
                .AddProcess(new OpenLoadingWindowProcess(_signalBus))
                .AddProcess(new CreateEmptySceneProcess(ELevelName.EMPTY.ToString()))
                .AddProcess(new UnloadProcess(ELevelName.GAME));
            
            if (!string.IsNullOrWhiteSpace(levelName))
            {
                var lastScene = SceneManager.GetSceneByName(_lastScene);
                if(lastScene.IsValid() && lastScene.isLoaded)
                    _processor.AddProcess(new UnloadProcess(_lastScene));
            }

            _processor
                .AddProcess(new LoadingProcess(ELevelName.GAME, LoadSceneMode.Additive))
                .AddProcess(new LoadingProcess(levelName, LoadSceneMode.Additive))
                .AddProcess(new SetActiveSceneProcess(levelName))
                .AddProcess(new UnloadProcess(ELevelName.EMPTY));
            
            _processor.AddProcess(new RunContextProcess("GameContext"))
                .AddProcess(new WaitUpdateProcess(1))
                .AddProcess(new ProjectWindowBack(_signalBus))
                .DoProcess();
            
            _lastScene = levelName;
        }

        public void LoadGameFromSplash()
        {
            var currentLevelId = _levelService.CurrentLevel;
            var currentLevelName = _levelService.GetLevelSceneName(currentLevelId);
            _lastScene = currentLevelName;
            _processor = new LoadingProcessor.Impls.LoadingProcessor();
            _processor
                .AddProcess(new OpenLoadingWindowProcess(_signalBus))
                .AddProcess(new LoadingProcess(ELevelName.GAME, LoadSceneMode.Additive))
                .AddProcess(new LoadingProcess(currentLevelName, LoadSceneMode.Additive))
                .AddProcess(new SetActiveSceneProcess(currentLevelName))
                .AddProcess(new UnloadProcess(ELevelName.SPLASH))
                .AddProcess(new RunContextProcess("GameContext"))
                .AddProcess(new WaitUpdateProcess(4))
                .AddProcess(new ProjectWindowBack(_signalBus))
                .DoProcess();
        }

        public float GetProgress()
        {
            return _processor.Progress;
        }
    }
}