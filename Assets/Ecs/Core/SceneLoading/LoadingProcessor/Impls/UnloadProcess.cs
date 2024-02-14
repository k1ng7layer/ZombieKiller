﻿using System;
using Ecs.Core.SceneLoading.SceneLoadingManager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.LoadingProcessor.Impls
{
    public class UnloadProcess : Process
    {
        private readonly string _levelName;
        private Action _complete;

        public UnloadProcess(ELevelName levelName)
        {
            _levelName = levelName.ToString();
        }
        
        public UnloadProcess(string levelName)
        {
            _levelName = levelName;
        }

        public override void Do(Action complete)
        {
            _complete = complete;
            var unloadSceneAsync = SceneManager.UnloadSceneAsync(_levelName);
            unloadSceneAsync.completed += OnUnloadSceneCompleted;
        }

        private void OnUnloadSceneCompleted(AsyncOperation obj)
        {
            var unloadUnusedAssets = Resources.UnloadUnusedAssets();
            unloadUnusedAssets.completed += OnUnloadUnusedAssetsCompleted;
        }

        private void OnUnloadUnusedAssetsCompleted(AsyncOperation obj)
        {
            _complete();
        }
    }
}