using Db.Abilities;
using Ecs.Commands.Command.Abilities;
using Ecs.Extensions.UidGenerator;
using Game.Providers.Projectile;
using Game.Providers.RandomProvider;
using Game.Services.Pools.Spot;
using Game.Utils;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;
using UnityEngine;

namespace Ecs.Commands.Systems.Abilities
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 225, nameof(EFeatures.Combat))]
    public class CastArtilleryShotSystem : ForEachCommandUpdateSystem<CastArtilleryShotAbilityCommand>
    {
        private readonly ICommandBuffer _commandBuffer;
        private readonly IAbilitiesBase _abilitiesBase;
        private readonly IRandomProvider _randomProvider;
        private readonly ISpotPool _spotPool;
        private readonly IProjectileProvider _projectileProvider;
        private readonly GameContext _game;

        public CastArtilleryShotSystem(
            ICommandBuffer commandBuffer, 
            IAbilitiesBase abilitiesBase,
            IRandomProvider randomProvider,
            ISpotPool spotPool,
            IProjectileProvider projectileProvider,
            GameContext game
        ) : base(commandBuffer)
        {
            _commandBuffer = commandBuffer;
            _abilitiesBase = abilitiesBase;
            _randomProvider = randomProvider;
            _spotPool = spotPool;
            _projectileProvider = projectileProvider;
            _game = game;
        }

        protected override void Execute(ref CastArtilleryShotAbilityCommand command)
        {
            var waypoints = new Vector3[2];
            var startPoint = command.Origin;
            startPoint.y += 18f;
            
            waypoints[0] = startPoint;
            waypoints[1] = command.Target;
            var abilityParams = _abilitiesBase.Get(EAbilityType.ArtilleryShot);

            var projectile = _projectileProvider.CreateProjectileWithTrajectory(
                command.Owner,
                command.Origin + new Vector3(0f, 2f, 0f), 
                waypoints, 
                EProjectileType.FireBall, 
                abilityParams.Speed);
            
            

            var spot = _game.CreateEntity();
            var spotUid = UidGenerator.Next();
            spot.AddUid(spotUid);
            spot.IsSpot = true;
            spot.AddPosition(command.Target);
            
            projectile.AddVfx(spotUid);

            var spotView = _spotPool.Spawn();
            spotView.Link(spot);
            spot.AddLink(spotView);
        }
    }
}