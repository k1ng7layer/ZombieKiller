using Db.Abilities;
using Ecs.Commands;
using Game.Utils;
using JCMG.EntitasRedux.Commands;
using UnityEngine;

namespace Game.Services.Ai.AbilityParams
{
    public class ArtilleryShotAbilityParams : IAbilityCastParams
    {
        private readonly ICommandBuffer _commandBuffer;
        private readonly IAbilitiesBase _abilitiesBasel;
        private readonly GameContext _game;

        public ArtilleryShotAbilityParams(
            ICommandBuffer commandBuffer,
            IAbilitiesBase abilitiesBasel,
            GameContext game
        )
        {
            _commandBuffer = commandBuffer;
            _abilitiesBasel = abilitiesBasel;
            _game = game;
        }
        
        public EAbilityType AbilityType => EAbilityType.ArtilleryShot;
        
        public void UseAbility(GameEntity entity)
        {
            var origin = entity.Position.Value;
            var uid = entity.Uid.Value;
            var playerPos = _game.PlayerEntity.Position.Value;
            
            var ability = _game.CreateEntity();
            var abilityParams = _abilitiesBasel.Get(EAbilityType.ArtilleryShot);
            ability.AddOwner(uid);
            ability.AddAbility(EAbilityType.ArtilleryShot);
            ability.AddAttackCooldown(abilityParams.Reload);
            
            for (int i = 0; i < 4; i++)
            {
                var random = Vector3.one * Random.insideUnitCircle * 4f;
                var targetPoint = playerPos + new Vector3(random.x, 0f, random.y);
                _commandBuffer.CastArtilleryShotAbility(uid, origin, targetPoint);
            }
        }
    }
}