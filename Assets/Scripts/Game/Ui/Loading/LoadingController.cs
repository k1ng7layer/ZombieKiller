using System;
using System.Collections;
using SimpleUi.Abstracts;
using UniRx;
using UnityEngine;

namespace Game.Ui.Loading
{
    public class LoadingController : UiController<LoadingView>
    {
        private IDisposable _loading;
        
        public override void OnShow()
        {
            _loading = Observable.FromCoroutine(InteractiveLoading).Subscribe();
        }

        public override void OnHide()
        {
            _loading.Dispose();
        }

        private IEnumerator InteractiveLoading()
        {
            var original = $"Loading";
            var resultText = $"Loading";
            string dots = ".";
            int start = 1;
            int max = 1;
            int current = 1;
            
            for (int i = 0; i < 4; i++)
            {
                View.LoadingText.text = resultText;
                
                yield return new WaitForSeconds(0.3f);
                
                resultText += dots;
                
                if (i == 3)
                {
                    resultText = original;
                    i = 0;
                }
            }
        }
    }
}