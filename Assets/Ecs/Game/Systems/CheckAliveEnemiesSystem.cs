using System.Collections.Generic;
using Ecs.Commands;
using Ecs.Utils.Groups;
using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Game.Systems
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 850, nameof(EFeatures.Common))]
    public class CheckAliveEnemiesSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGameGroupUtils _gameGroupUtils;
        private readonly ICommandBuffer _commandBuffer;

        public CheckAliveEnemiesSystem(
            GameContext game, 
            IGameGroupUtils gameGroupUtils, 
            ICommandBuffer commandBuffer
        ) : base(game)
        {
            _gameGroupUtils = gameGroupUtils;
            _commandBuffer = commandBuffer;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Dead);

        protected override bool Filter(GameEntity entity) => entity.HasEnemy && entity.IsDead && !entity.IsDestroyed;

        protected override void Execute(IEnumerable<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                using var enemyGroup = _gameGroupUtils.GetEnemies(out var enemies, e => !e.IsDead);
                
                if (enemies.Count > 0)
                    continue;
                
                _commandBuffer.StageWin();
            }
        }
    }
}