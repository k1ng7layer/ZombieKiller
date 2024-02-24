using System.Collections.Generic;
using JCMG.EntitasRedux;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;
using UnityEngine;

namespace Ecs.Game.Systems.Player
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 800, nameof(EFeatures.Common))]
    public class FreezePlayerSystem : ReactiveSystem<GameEntity>
    {
        public FreezePlayerSystem(GameContext game) : base(game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.CanMove.Removed());

        protected override bool Filter(GameEntity entity) => entity.IsPlayer && !entity.IsDestroyed;

        protected override void Execute(IEnumerable<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (!entity.IsCanMove)
                {
                    entity.ReplaceMoveDirection(Vector3.zero);
                }
            }
        }
    }
}