using Ecs.Core.Interfaces;
using Ecs.Utils.Groups;
using JCMG.EntitasRedux;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Game.Systems.Combat
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 900, nameof(EFeatures.Combat))]
    public class AttackCooldownSystem : IUpdateSystem
    {
        private readonly IGameGroupUtils _gameGroupUtils;
        private readonly ITimeProvider _timeProvider;
        private readonly GameContext _game;

        public AttackCooldownSystem(
            IGameGroupUtils gameGroupUtils, 
            ITimeProvider timeProvider,
            GameContext game
        )
        {
            _gameGroupUtils = gameGroupUtils;
            _timeProvider = timeProvider;
            _game = game;
        }
        
        public void Update()
        {
            using var unitGroup = _gameGroupUtils.GetUnits(out var units, u => u.HasAttackCooldown && !u.IsDead);

            foreach (var unit in units)
            {
                var cd = unit.AttackCooldown.Value;
                
                if (cd <= 0)
                    continue;

                cd -= _timeProvider.DeltaTime;
                unit.ReplaceAttackCooldown(cd);
                if (cd <= 0)
                {
                    var weapon = _game.GetEntityWithUid(unit.EquippedWeapon.Value.WeaponEntityUid);

                    // weapon.IsPerformingAttack = false;
                    // unit.IsPerformingAttack = false;
                }
            }
        }
    }
}