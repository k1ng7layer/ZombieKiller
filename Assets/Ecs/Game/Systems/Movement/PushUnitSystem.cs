using Ecs.Core.Interfaces;
using Ecs.Utils.Groups;
using JCMG.EntitasRedux;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;
using UnityEngine;

namespace Ecs.Game.Systems.Movement
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 1100, nameof(EFeatures.Input))]
    public class PushUnitSystem : IUpdateSystem
    {
        private readonly ITimeProvider _timeProvider;
        private readonly IGameGroupUtils _gameGroupUtils;

        public PushUnitSystem(
            ITimeProvider timeProvider, 
            IGameGroupUtils gameGroupUtils
        )
        {
            _timeProvider = timeProvider;
            _gameGroupUtils = gameGroupUtils;
        }
        
        public void Update()
        {
            using var unitsGroup = _gameGroupUtils.GetUnits(out var units, 
                u => u.HasPushForce && u.HasPushDirection && !u.IsDead);

            foreach (var unit in units)
            {
                var force = unit.PushForce.Value;
                
                if (force <= 0.01f)
                    continue;
                
                var direction = unit.MoveDirection.Value;
                var pushDir = unit.PushDirection.Value;

                force -= _timeProvider.DeltaTime * 3f;
                force = Mathf.Clamp(force, 0f, 3f);
                
                //direction += pushDir;
                
                Debug.Log($"PushUnitSystem, direction: {direction}, pushDir: {pushDir}, force: {force}");
                var dir = unit.Transform.Value.TransformDirection(pushDir.normalized * force);
                //unit.ReplaceMoveDirection(pushDir.normalized * force * _timeProvider.DeltaTime);
                unit.ReplacePushForce(force);
                unit.ReplacePushDirection((pushDir.normalized) * force * _timeProvider.DeltaTime);
               // unit.CharacterController.Value.Move(pushDir.normalized * force * _timeProvider.DeltaTime);

                if (force == 0)
                {
                   // unit.ReplacePushDirection(Vector3.zero);
                    //unit.IsCanMove = true;
                }
            }
        }
    }
}