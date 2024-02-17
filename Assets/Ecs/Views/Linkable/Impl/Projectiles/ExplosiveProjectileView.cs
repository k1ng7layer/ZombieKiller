using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Core.Utils;
using UnityEngine;

namespace Ecs.Views.Linkable.Impl.Projectiles
{
    public class ExplosiveProjectileView : ProjectileView
    {
        [SerializeField] private GameObject _explosiveFxGo;

        private ParticleSystem _fx;

        protected override void Subscribe(IEntity entity, IUnsubscribeEvent unsubscribe)
        {
            base.Subscribe(entity, unsubscribe);

            _fx = _explosiveFxGo.GetComponent<ParticleSystem>();
        }

        protected override void OnClear()
        {
            _fx.Play();
        }
    }
}