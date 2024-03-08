using System.Collections.Generic;
using Game.AI;
using JCMG.EntitasRedux;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Game.Systems.Initialize
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 60, nameof(EFeatures.Initialization))]
    public class AiInitializeSystem : ReactiveSystem<GameEntity>
    {
        private readonly IBehaviourTreeFactory _behaviourTreeFactory;

        public AiInitializeSystem(
            GameContext game,
            IBehaviourTreeFactory behaviourTreeFactory
        ) : base(game)
        {
            _behaviourTreeFactory = behaviourTreeFactory;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
            => context.CreateCollector(GameMatcher.Ai);

        protected override bool Filter(GameEntity entity)
            => entity.IsAi && !entity.HasBehaviourTree && !entity.IsDestroyed;

        protected override void Execute(IEnumerable<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                var behaviorTree = _behaviourTreeFactory.Create(gameEntity);
                gameEntity.AddBehaviourTree(behaviorTree);
            }
        }
    }
}