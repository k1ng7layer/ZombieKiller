using System.Collections.Generic;
using JCMG.EntitasRedux;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Game.Systems.Combat
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 1000, nameof(EFeatures.Combat))]
    public class EnemyDeathSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _game;

        public EnemyDeathSystem(GameContext game) : base(game)
        {
            _game = game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Health);

        protected override bool Filter(GameEntity entity) => entity.Health.Value <= 0 && !entity.IsDead && !entity.IsDestroyed;

        protected override void Execute(IEnumerable<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDead = true;
                var weaponInfo = entity.EquippedWeapon.Value;
                var weapon = _game.GetEntityWithUid(weaponInfo.WeaponEntityUid);
                weapon.IsPerformingAttack = false;
            }
        }
    }
}