using Ecs.Core.Systems;
using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Game.Systems.Stats
{
    public abstract class AUnitAttributeCalcSystem<TComponent> : AComponentReplacedReactiveSystem<GameEntity, TComponent, float>  where TComponent : class, IComponent
    {
        public AUnitAttributeCalcSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected abstract override float GetValue(TComponent component);

        protected override void OnReplaced(GameEntity entity, float last, float next)
        {
            if (!Filter(entity))
                return;

            var additionalValue = GetAdditionalValue(entity);
            var baseValue = GetBaseValue(entity);
            var maxValue = GetMaxValue(entity);
            
            if (next > maxValue)
            {
                var reminder = next - maxValue;
                baseValue += reminder;
                baseValue = Mathf.Clamp(baseValue, 0, maxValue - additionalValue);
            }
            else
            {
                var diff = next - last;

                if (diff > 0)
                {
                    baseValue += diff;
                }
                else
                {
                    float reminder = 0;

                    if (additionalValue > 0)
                    {
                        additionalValue += diff;

                        if (additionalValue < 0)
                            reminder = additionalValue;
                        
                        additionalValue = Mathf.Clamp(additionalValue, 0, maxValue - baseValue);
                        baseValue += reminder;
                    }
                    else
                    {
                        baseValue += diff;
                    }
                    
                    baseValue = Mathf.Clamp(baseValue, 0, maxValue);
                }
            }

            UpdateBaseValue(baseValue, entity);
            UpdateAdditionalValue(additionalValue, entity);
            var value = baseValue + additionalValue;
            UpdateValue(value, entity);
        }

        protected abstract bool Filter(GameEntity entity);

        protected abstract float GetBaseValue(GameEntity entity);
        protected abstract float GetAdditionalValue(GameEntity entity);
        protected abstract float GetMaxValue(GameEntity entity);
        protected abstract void UpdateBaseValue(float value, GameEntity entity);
        protected abstract void UpdateAdditionalValue(float value, GameEntity entity);
        protected abstract void UpdateValue(float value, GameEntity entity);
    }
}