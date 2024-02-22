using Ecs.Utils.Groups;
using JCMG.EntitasRedux;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;
using UnityEngine;

namespace Ecs.Game.Systems.Combat
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 400, nameof(EFeatures.Combat))]
    public class TimeCountSystem : IUpdateSystem
    {
        private readonly IGameGroupUtils _gameGroupUtils;
        
        public TimeCountSystem(IGameGroupUtils gameGroupUtils)
        {
            _gameGroupUtils = gameGroupUtils;
        }
        
        public void Update()
        {
            var deltaTime = Time.deltaTime;
            
            using var timeEntities = _gameGroupUtils.GetTimeEntities(out var timeBuffer, true);
            
            foreach (var timeEntity in timeBuffer)
            {
                var currentTime = timeEntity.Time.Value;
                currentTime -= deltaTime;
                
                timeEntity.ReplaceTime(currentTime);
            }
        }
    }
}