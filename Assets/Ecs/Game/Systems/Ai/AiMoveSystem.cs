using Ecs.Utils.Groups;
using Game.Extensions;
using JCMG.EntitasRedux;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;
using UnityEngine;

namespace Ecs.Game.Systems.Ai
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 1050, nameof(EFeatures.Ai))]
    public class AiMoveSystem : IUpdateSystem
    {
        private readonly IGameGroupUtils _gameGroupUtils;

        public AiMoveSystem(IGameGroupUtils gameGroupUtils)
        {
            _gameGroupUtils = gameGroupUtils;
        }
        
        public void Update()
        {
            using var aiGroup = _gameGroupUtils.GetAi(out var aiEntities, e => e.HasBehaviourTree && e.HasNavmeshAgent && e.IsMoving && !e.IsDead);

            foreach (var entity in aiEntities)
            {
                var navMesh = entity.NavmeshAgent.Value;

                var delta = navMesh.nextPosition - entity.Position.Value;
                // if (delta.NoY().sqrMagnitude > 0.00001f)
                // {
                //     aiEntity.IsPathCompleted = false;
                // }
                // else
                // {
                //     aiEntity.IsPathCompleted = true;
                // }
               // Debug.Log(\);

               var currentRot = entity.Rotation.Value;
               var targetRot = Quaternion.LookRotation(delta.NoY());

               var tt = Quaternion.RotateTowards(currentRot, targetRot, 3f);
               
               // if (delta.magnitude >= 0.01f)
               //  
               //var targetRot = 
               entity.ReplaceRotation(tt);
               entity.ReplaceMoveDirection(delta * entity.MoveSpeed.Value);
                
            }
        }
    }
}