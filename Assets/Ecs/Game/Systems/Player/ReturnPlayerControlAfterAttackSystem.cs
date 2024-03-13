using System.Collections.Generic;
using JCMG.EntitasRedux;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;
using UnityEngine;

namespace Ecs.Game.Systems.Player
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 180, nameof(EFeatures.Combat))]
    public class ReturnPlayerControlAfterAttackSystem : ReactiveSystem<GameEntity>
    {
        public ReturnPlayerControlAfterAttackSystem(GameContext game) : base(game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.PerformingAttack.Removed());

        protected override bool Filter(GameEntity entity) =>
            entity.IsPlayer && !entity.IsDestroyed;

        protected override void Execute(IEnumerable<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsCanMove = true;
            }
        }
    }
}