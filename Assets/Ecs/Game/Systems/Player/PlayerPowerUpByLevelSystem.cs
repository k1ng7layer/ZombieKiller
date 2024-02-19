using System.Collections.Generic;
using Ecs.Commands;
using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Game.Systems.Player
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 740, nameof(EFeatures.Combat))]
    public class PlayerPowerUpByLevelSystem : ReactiveSystem<GameEntity>
    {
        private readonly ICommandBuffer _commandBuffer;

        public PlayerPowerUpByLevelSystem(GameContext game, ICommandBuffer commandBuffer) : base(game)
        {
            _commandBuffer = commandBuffer;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.UnitLevel);

        protected override bool Filter(GameEntity entity) 
            => entity.IsPlayer 
               && entity.HasUnitLevel 
               && entity. UnitLevel.Value > 1 
               && !entity.IsDestroyed;

        protected override void Execute(IEnumerable<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                for (int i = 0; i < 3; i++)
                {
                    _commandBuffer.CreatePowerUp(entity.Uid.Value);
                }
            }
        }
    }
}