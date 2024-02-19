using System.Collections.Generic;
using Db.Player;
using Game.Ui.PlayerStats.LevelUp;
using JCMG.EntitasRedux;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;
using SimpleUi.Signals;
using Zenject;

namespace Ecs.Game.Systems.Player
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 720, nameof(EFeatures.Combat))]
    public class PlayerLevelUpSystem : ReactiveSystem<GameEntity>
    {
        private readonly SignalBus _signalBus;
        private readonly IPlayerSettings _playerSettings;

        public PlayerLevelUpSystem(GameContext game, SignalBus signalBus, IPlayerSettings playerSettings) : base(game)
        {
            _signalBus = signalBus;
            _playerSettings = playerSettings;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Experience);

        protected override bool Filter(GameEntity entity) =>
            entity.IsPlayer && entity.HasExperience && !entity.IsDestroyed;

        protected override void Execute(IEnumerable<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var level = entity.UnitLevel.Value;
                var expGoal = _playerSettings.LevelRequiredExpMultiplier * level * _playerSettings.BaseExperienceRequired;
                var currExp = entity.Experience.Value;
                
                if (currExp >= expGoal)
                {
                    entity.ReplaceUnitLevel(level + 1);
                    _signalBus.OpenWindow<LevelUpWindow>();
                }
            }
        }
    }
}