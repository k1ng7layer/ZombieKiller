using Ecs.Utils.Groups;
using JCMG.EntitasRedux;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Game.Systems.Ai
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 1000, nameof(EFeatures.Ai))]
    public class BehaviourTreeUpdateSystem : IUpdateSystem
    {
        private readonly IGameGroupUtils _gameGroupUtils;

        public BehaviourTreeUpdateSystem(IGameGroupUtils gameGroupUtils)
        {
            _gameGroupUtils = gameGroupUtils;
        }
        
        public void Update()
        {
            using var aiGroup = _gameGroupUtils.GetAi(out var aiEntities, e => e.HasBehaviourTree && !e.IsDead);
            
            foreach (var aiEntity in aiEntities)
            {
                var behaviourTree = aiEntity.BehaviourTree.Value;
                
                behaviourTree.Tick();
            }
        }
    }
}