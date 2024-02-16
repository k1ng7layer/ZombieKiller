
using Ecs.Extensions.UidGenerator;
using UnityEngine;

namespace Ecs.Game.Extensions
{
    public static class GameExtensions
    {
        
        public static GameEntity CreateCamera(
            this GameContext game, 
            Transform cameraTransform
        )
        {
            var entity = game.CreateEntity();
            entity.AddUid(UidGenerator.Next());
            entity.AddPosition(cameraTransform.position);
            entity.AddRotation(cameraTransform.rotation);
            entity.IsCamera = true;
            
            return entity;
        }
    }
}