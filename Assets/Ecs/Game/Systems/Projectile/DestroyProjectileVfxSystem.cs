using System.Collections.Generic;
using Ecs.Views.Linkable.Impl.Spots;
using Game.Services.Pools.Spot;
using JCMG.EntitasRedux;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Game.Systems.Projectile
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 1020, nameof(EFeatures.Combat))]
    public class DestroyProjectileVfxSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _game;
        private readonly ISpotPool _spotPool;

        public DestroyProjectileVfxSystem(GameContext game, ISpotPool spotPool) : base(game)
        {
            _game = game;
            _spotPool = spotPool;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Dead);

        protected override bool Filter(GameEntity entity) =>
            entity.HasProjectile && entity.HasVfx;

        protected override void Execute(IEnumerable<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var vfxUid = entity.Vfx.VfxUid;
                var vfxEntity = _game.GetEntityWithUid(vfxUid);
                var spotView = (SpotView)vfxEntity.Link.View;
                vfxEntity.IsDestroyed = true;
                _spotPool.Despawn(spotView);
            }
        }
    }
}