using Ecs.Core.SceneLoading.SceneLoadingManager;
using Ecs.Utils.Interfaces;
using Game.Services.LevelService;
using SimpleUi.Abstracts;
using UniRx;

namespace Game.Ui.Debug
{
    public class ReloadButtonController : UiController<ReloadButtonView>, IUiInitialize
    {
        private readonly ISceneLoadingManager _sceneLoadingManager;
        private readonly ILevelService _levelService;

        public ReloadButtonController(
            ISceneLoadingManager sceneLoadingManager, 
            ILevelService levelService
        )
        {
            _sceneLoadingManager = sceneLoadingManager;
            _levelService = levelService;
        }
        
        public void Initialize()
        {
            View.ReloadBtn.OnClickAsObservable().Subscribe(_ =>
            {
                var levelName = _levelService.GetLevelSceneName(_levelService.CurrentLevel);
                _sceneLoadingManager.LoadGameLevel(levelName);
            }).AddTo(View.gameObject);
        }
    }
}