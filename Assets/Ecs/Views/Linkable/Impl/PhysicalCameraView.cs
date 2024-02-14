using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Core.Utils;

namespace Ecs.Views.Linkable.Impl
{
    public class PhysicalCameraView : ObjectView
    {
        protected override void Subscribe(IEntity entity, IUnsubscribeEvent unsubscribe)
        {
            base.Subscribe(entity, unsubscribe);
            
            //SelfEntity.AddTransform(transform);
        }
    }
}