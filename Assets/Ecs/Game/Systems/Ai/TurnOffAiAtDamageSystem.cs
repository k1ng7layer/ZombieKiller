using System.Collections.Generic;
using JCMG.EntitasRedux;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Game.Systems.Ai
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 225, nameof(EFeatures.Combat))]
    public class TurnOffAiAtDamageSystem : ReactiveSystem<GameEntity>
    {
        public TurnOffAiAtDamageSystem(GameContext game) : base(game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.HitCounter);

        protected override bool Filter(GameEntity entity) => entity.IsAi && entity.HasHitCounter && !entity.IsDestroyed;

        protected override void Execute(IEnumerable<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                //entity.IsActive = false;
            }
        }
    }
}