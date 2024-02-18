using System.Collections.Generic;
using Db.Player;
using JCMG.EntitasRedux;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Game.Systems.Player
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 720, nameof(EFeatures.Combat))]
    public class AddPlayerExperienceByEnemyDeadSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _game;
        private readonly IPlayerSettings _playerSettings;

        public AddPlayerExperienceByEnemyDeadSystem(
            GameContext game, 
            IPlayerSettings playerSettings
        ) : base(game)
        {
            _game = game;
            _playerSettings = playerSettings;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Dead);

        protected override bool Filter(GameEntity entity) => 
            entity.HasEnemy && entity.HasExperience && entity.IsDead && !entity.IsDestroyed;

        protected override void Execute(IEnumerable<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var player = _game.PlayerEntity;
                var playerExp = player.Experience.Value;
                playerExp += entity.Experience.Value * _playerSettings.LevelGainExpMultiplier;
                
                player.ReplaceExperience(playerExp);
            }
        }
    }
}