using System.Collections.Generic;
using Db.Player;
using Ecs.Commands;
using Game.Ui.PlayerStats.LevelUp;
using Game.Utils;
using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Commands;
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
        private readonly ICommandBuffer _commandBuffer;

        public PlayerLevelUpSystem(
            GameContext game, 
            SignalBus signalBus, 
            IPlayerSettings playerSettings,
            ICommandBuffer commandBuffer
        ) : base(game)
        {
            _signalBus = signalBus;
            _playerSettings = playerSettings;
            _commandBuffer = commandBuffer;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Experience);

        protected override bool Filter(GameEntity entity) =>
            entity.IsPlayer && entity.HasExperience && !entity.IsDestroyed;

        protected override void Execute(IEnumerable<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity.UnitLevel.Value == 0)
                    continue;
                
                var level = entity.UnitLevel.Value;
                var expGoal = _playerSettings.LevelRequiredExpMultiplier * level * _playerSettings.BaseExperienceRequired;
                var currExp = entity.Experience.Value;
                
                if (currExp >= expGoal)
                {
                    entity.ReplaceUnitLevel(level + 1);
                    entity.IsCanMove = false;
                    _signalBus.OpenWindow<LevelUpWindow>();
                    _commandBuffer.SetGameState(EGameState.Pause);
                }
            }
        }
    }
}