using Ecs.Core.Interfaces;
using Ecs.Utils.Groups;
using Game.Providers.RandomProvider;
using JCMG.EntitasRedux;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;
using UnityEngine;

namespace Ecs.Game.Systems.Collectables
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 970, nameof(EFeatures.Combat))]
    public class CollectableFallSystem : IUpdateSystem
    {
        private readonly IGameGroupUtils _gameGroupUtils;
        private readonly IRandomProvider _randomProvider;
        private readonly ITimeProvider _timeProvider;

        public CollectableFallSystem(
            IGameGroupUtils gameGroupUtils, 
            IRandomProvider randomProvider,
            ITimeProvider timeProvider
        )
        {
            _gameGroupUtils = gameGroupUtils;
            _randomProvider = randomProvider;
            _timeProvider = timeProvider;
        }
        
        public void Update()
        {
            using var collectablesGr = _gameGroupUtils.GetCollectables(out var collectables, c => c.HasMoveDirection);

            foreach (var collectable in collectables)
            {
                var pos = collectable.Position.Value;
                var moveDir = collectable.MoveDirection.Value;
                pos += moveDir * _timeProvider.DeltaTime;
                collectable.ReplacePosition(pos);
                
                var deltaRotation = Quaternion.Euler(new Vector3(_randomProvider.Range(150f, 250f), 
                    _randomProvider.Range(150f, 250f), _randomProvider.Range(-150f, 150f)) * _timeProvider.DeltaTime);

                collectable.ReplaceRotation(collectable.Rotation.Value * deltaRotation);
                
                if (moveDir.y < -4f)
                    moveDir.y = -4f;
                else
                {
                    moveDir -= Vector3.up * 9 * _timeProvider.DeltaTime;
                }
                
                collectable.ReplaceMoveDirection(moveDir);
                var collectableInfo = collectable.Collectable.CollectableInfo;

                Debug.Log($"CollectableFallSystem: {(pos.y - collectableInfo.DropCenter.y)}, moveDir: {moveDir}");
                if ((pos.y - collectableInfo.DropCenter.y) <= 0.01f && moveDir.y < 0f)
                {
                    collectable.RemoveMoveDirection();
                    collectable.ReplaceRotation(Quaternion.identity);
                }
            }
        }
    }
}