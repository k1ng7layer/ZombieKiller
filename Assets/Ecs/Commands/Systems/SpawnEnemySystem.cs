using Db.Enemies;
using Ecs.Commands.Systems.Spawn;
using Ecs.Extensions.UidGenerator;
using Ecs.Game.Extensions;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Commands.Systems
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 500, nameof(EFeatures.Spawn))]
    public class SpawnEnemySystem : ForEachCommandUpdateSystem<SpawnEnemyCommand>
    {
        private readonly IEnemyParamsBase _enemyParamsBase;
        private readonly GameContext _game;

        public SpawnEnemySystem(
            ICommandBuffer commandBuffer, 
            IEnemyParamsBase enemyParamsBase,
            GameContext game
        ) : base(commandBuffer)
        {
            _enemyParamsBase = enemyParamsBase;
            _game = game;
        }

        protected override void Execute(ref SpawnEnemyCommand command)
        {
            var enemyType = command.EnemyType;
            var enemyParams = _enemyParamsBase.GetEnemyParams(enemyType);

            _game.CreateEnemy(enemyType, enemyParams, command.Position, command.Rotation);
        }
    }
}