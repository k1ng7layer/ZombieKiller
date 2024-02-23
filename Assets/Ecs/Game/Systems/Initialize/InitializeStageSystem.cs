using Ecs.Commands;
using Ecs.Utils.LinkedEntityRepository;
using Game.Providers.GameFieldProvider;
using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Game.Systems.Initialize
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 50, nameof(EFeatures.Initialization))]
    public class InitializeStageSystem : IInitializeSystem
    {
        private readonly ICommandBuffer _commandBuffer;
        private readonly IGameFieldProvider _gameFieldProvider;
        private readonly ILinkedEntityRepository _linkedEntityRepository;
        private readonly GameContext _game;

        public InitializeStageSystem(
            ICommandBuffer commandBuffer,
            IGameFieldProvider gameFieldProvider,
            ILinkedEntityRepository linkedEntityRepository,
            GameContext game
        )
        {
            _commandBuffer = commandBuffer;
            _gameFieldProvider = gameFieldProvider;
            _linkedEntityRepository = linkedEntityRepository;
            _game = game;
        }

        public void Initialize()
        {
            foreach (var enemySpawnPoint in _gameFieldProvider.GameField.EnemySpawnPoints)
            {
                _commandBuffer.SpawnEnemy(
                    enemySpawnPoint.EnemyType, 
                    enemySpawnPoint.SpawnTransform.position, 
                    enemySpawnPoint.SpawnTransform.rotation);
            }

            InitPortals();
        }

        private void InitPortals()
        {
            var gameField = _gameFieldProvider.GameField;

            foreach (var portalView in gameField.LevelPortals)
            {
                var portalEntity = _game.CreateEntity();
                portalEntity.AddPortal(portalView.PortalDestination);
                portalView.Link(portalEntity);
                portalEntity.IsActive = false;
                
                _linkedEntityRepository.Add(portalView.transform.GetHashCode(), portalEntity);
            }
        }
    }
}