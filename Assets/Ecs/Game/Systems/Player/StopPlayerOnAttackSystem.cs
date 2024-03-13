using System.Collections.Generic;
using JCMG.EntitasRedux;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;
using UnityEngine;

namespace Ecs.Game.Systems.Player
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 180, nameof(EFeatures.Combat))]
    public class StopPlayerOnAttackSystem : ReactiveSystem<GameEntity>
    {
        public StopPlayerOnAttackSystem(GameContext game) : base(game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.PerformingAttack);

        protected override bool Filter(GameEntity entity) =>
            entity.IsPlayer && entity.IsPerformingAttack && !entity.IsDestroyed;

        protected override void Execute(IEnumerable<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.ReplaceMoveDirection(Vector3.zero);
            }
        }
    }
}