using System.Threading;
using DG.Tweening;
using UniRx.Async;

namespace Game.Extensions
{
    public static class DoTweenExtensions
    {
        public static UniTask ToUniTask(this Tweener tweener, CancellationToken token)
        {
            var tcs = new UniTaskCompletionSource();
            token.Register(Cancel);
                
            void TweenCallback()
            {
                tweener.onComplete -= TweenCallback;
                tcs.TrySetResult();
            }

            void Cancel()
            {
                tweener.onComplete -= TweenCallback;
                tcs.TrySetCanceled();
            }

            tweener.onComplete += TweenCallback;

            return tcs.Task;
        }
    }
}