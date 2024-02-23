using System;
using System.Collections.Generic;
using SimpleUi.Abstracts;
using SimpleUi.Interfaces;

namespace Game.Ui.Utils
{
    public class UiManagedController<T> : UiController<T>, IDisposable where T : IUiView
    {
        protected readonly List<IDisposable> _disposables = new();
        
        public void Dispose()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}