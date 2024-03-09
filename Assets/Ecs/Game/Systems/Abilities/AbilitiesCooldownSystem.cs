using Ecs.Core.Interfaces;
using Ecs.Utils.Groups;
using JCMG.EntitasRedux;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Game.Systems.Abilities
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 700, nameof(EFeatures.Combat))]
    public class AbilitiesCooldownSystem : IUpdateSystem
    {
        private readonly IGameGroupUtils _gameGroupUtils;
        private readonly ITimeProvider _timeProvider;

        public AbilitiesCooldownSystem(
            IGameGroupUtils gameGroupUtils, 
            ITimeProvider timeProvider
        )
        {
            _gameGroupUtils = gameGroupUtils;
            _timeProvider = timeProvider;
        }
        
        public void Update()
        {
            using var abilitiesGroup = _gameGroupUtils.GetAbilities(out var abilities, 
                a => a.HasAttackCooldown);

            foreach (var ability in abilities)
            {
                var cd = ability.AttackCooldown.Value;

                cd -= _timeProvider.DeltaTime;
                ability.ReplaceAttackCooldown(cd);

                if (cd <= 0f)
                {
                    ability.IsDestroyed = true;
                }
            }
        }
    }
}