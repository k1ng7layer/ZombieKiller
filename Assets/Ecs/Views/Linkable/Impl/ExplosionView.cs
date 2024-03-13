using Game.Utils;
using UniRx;
using UnityEngine;

namespace Ecs.Views.Linkable.Impl
{
    public class ExplosionView : ObjectView
    {
        [SerializeField] private int lifeTime;
        [SerializeField] private ParticleSystem _explosionVfx;

        //[Inject] private IExplosionPoolRepository _explosionPoolRepository;

        private EExplosionType _explosionType;

        public float LifeTime => lifeTime;

        public void Init(EExplosionType explosionType)
        {
            _explosionType = explosionType;
            
            Observable.NextFrame().Subscribe(_ =>
            {
                _explosionVfx.gameObject.SetActive(true);
                _explosionVfx.Play();
            });
        }

        public void Hide()
        {
            _explosionVfx.gameObject.SetActive(false);
            
            // var pool = _explosionPoolRepository.Get(_explosionType);
            // pool.Despawn(this);
        }
    }
}