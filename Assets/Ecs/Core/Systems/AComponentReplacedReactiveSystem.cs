using System;
using JCMG.EntitasRedux;

namespace Ecs.Core.Systems
{
    public abstract class AComponentReplacedReactiveSystem<TEntity, TComponent, TValue> : ComponentReplacedReactiveSystem<TEntity, TComponent, TValue> where TEntity : class, IEntity
        where TComponent : class, IComponent
    {
        public AComponentReplacedReactiveSystem(IContext<TEntity> context) : base(context)
        {
        }

        protected override Type[] GetComponentTypes() => GameComponentsLookup.ComponentTypes;
        
    }
}