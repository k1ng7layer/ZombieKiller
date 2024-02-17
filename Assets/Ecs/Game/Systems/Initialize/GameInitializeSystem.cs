using Ecs.Commands;
using Game.Providers.GameFieldProvider;
using Game.Utils;
using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Game.Systems.Initialize
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 50, nameof(EFeatures.Initialization))]
    public class GameInitializeSystem : IInitializeSystem
    {
        private readonly ICommandBuffer _commandBuffer;
        private readonly IGameFieldProvider _gameFieldProvider;

        public GameInitializeSystem(
            ICommandBuffer commandBuffer,
            IGameFieldProvider gameFieldProvider
        )
        {
            _commandBuffer = commandBuffer;
            _gameFieldProvider = gameFieldProvider;
        }

        public void Initialize()
        {
            foreach (var enemySpawnPoint in _gameFieldProvider.GameField.EnemySpawnPoints)
            {
                _commandBuffer.SpawnEnemy(EEnemyType.Type1, enemySpawnPoint.position, enemySpawnPoint.rotation);
            }
        }
    }
}