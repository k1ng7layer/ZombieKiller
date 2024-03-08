using System;
using Core.LoadingProcessor.Impls;
using UnityEngine.SceneManagement;

namespace Ecs.Core.SceneLoading.LoadingProcessor.Impls
{
    public class CreateEmptySceneProcess : Process
    {
        private readonly string _sceneName;

        public CreateEmptySceneProcess(string sceneName)
        {
            _sceneName = sceneName;
        }
        
        public override void Do(Action onComplete)
        {
            var scene = SceneManager.GetSceneByName(_sceneName);
            if (scene.IsValid() && scene.isLoaded)
            {
                onComplete();
            }
            else
            {
                SceneManager.CreateScene(_sceneName);
                onComplete();   
            }
        }
    }
}