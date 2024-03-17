using Ecs.Commands;
using Ecs.Extensions.UidGenerator;
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
            InitEnemies();
            InitPortals();
            InitBench();
        }

        private void InitEnemies()
        {
            if (!_gameFieldProvider.GameField.SpawnEnemies)
                return;
            
            foreach (var enemySpawnPoint in _gameFieldProvider.GameField.EnemySpawnPoints)
            {
                _commandBuffer.SpawnEnemy(
                    enemySpawnPoint.EnemyType, 
                    enemySpawnPoint.SpawnTransform.position, 
                    enemySpawnPoint.SpawnTransform.rotation);
            }
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

        private void InitBench()
        {
            var benchView = _gameFieldProvider.GameField.BenchView;
            
            if (benchView == null)
                return;
            
            var bench = _game.CreateEntity();
            benchView.Link(bench);
            bench.AddLink(benchView);
            
            bench.IsBench = true;
            bench.AddUid(UidGenerator.Next());
            bench.AddPosition(benchView.transform.position);
            bench.AddRotation(benchView.transform.rotation);
            bench.IsActive = true;
        }
    }
}