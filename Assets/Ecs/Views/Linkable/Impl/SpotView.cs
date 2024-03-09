using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Core.Utils;
using UnityEngine;

namespace Ecs.Views.Linkable.Impl
{
    public class SpotView : ObjectView
    {
        [SerializeField] private ParticleSystem _spotVfx;

        protected override void Subscribe(IEntity entity, IUnsubscribeEvent unsubscribe)
        {
            base.Subscribe(entity, unsubscribe);
        }

        public void SetState(bool v)
        {
            _spotVfx.gameObject.SetActive(v);
            
            if (v)
                _spotVfx.Play();
        }
        
        protected virtual void OnDead(GameEntity _)
        {
            
        }

        protected override void OnClear()
        {
            
        }
    }
}