namespace Ecs.Core.SceneLoading.SceneLoadingManager
{
    public interface ISceneLoadingManager
    {
        void LoadGameLevel(string levelName);
        void LoadGameFromSplash();
        float GetProgress();
    }
}