using Db.Player;
using Ecs.Commands;
using Ecs.Utils.Groups;
using Game.Services.Inventory;
using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Game.Systems.Collectables
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 900, nameof(EFeatures.Common))]
    public class CollectCollectablesByDistanceSystem : IUpdateSystem
    {
        private readonly GameContext _game;
        private readonly IGameGroupUtils _gameGroupUtils;
        private readonly IPlayerSettings _playerSettings;
        private readonly ICommandBuffer _commandBuffer;
        private readonly IPlayerInventoryService _playerInventoryService;

        public CollectCollectablesByDistanceSystem(
            GameContext game, 
            IGameGroupUtils gameGroupUtils, 
            IPlayerSettings playerSettings, 
            ICommandBuffer commandBuffer,
            IPlayerInventoryService playerInventoryService
        )
        {
            _game = game;
            _gameGroupUtils = gameGroupUtils;
            _playerSettings = playerSettings;
            _commandBuffer = commandBuffer;
            _playerInventoryService = playerInventoryService;
        }
        
        public void Update()
        {
            var playerPosition = _game.PlayerEntity.Position.Value;

            using var collectableGroup = _gameGroupUtils.GetCollectables(out var collectables);

            foreach (var collectable in collectables)
            {
                var position = collectable.Position.Value;
                var dist = _playerSettings.CollectItemsDist;

                if ((position - playerPosition).sqrMagnitude <= dist * dist)
                {
                    if (_playerInventoryService.IsFull)
                    {
                        //Notify player
                       continue; 
                    }
                    
                    _commandBuffer.CollectItem(collectable.Collectable.CollectableInfo.ItemId);
                    collectable.IsDestroyed = true;
                }
            }
        }
    }
}