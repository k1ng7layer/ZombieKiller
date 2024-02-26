using System.Collections.Generic;
using JCMG.EntitasRedux;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Game.Systems.Combat
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 900, nameof(EFeatures.Combat))]
    public class EnemyDeathSystem : ReactiveSystem<GameEntity>
    {
        public EnemyDeathSystem(GameContext game) : base(game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Health);

        protected override bool Filter(GameEntity entity) => entity.Health.Value <= 0 && !entity.IsDead && !entity.IsDestroyed;

        protected override void Execute(IEnumerable<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDead = true;
            }
        }
    }
}