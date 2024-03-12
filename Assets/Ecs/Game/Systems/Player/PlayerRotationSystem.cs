using Game.Services.InputService;
using JCMG.EntitasRedux;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;
using UnityEngine;

namespace Ecs.Game.Systems.Player
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 1000, nameof(EFeatures.Input))]
    public class PlayerRotationSystem : IUpdateSystem
    {
        private readonly IInputService _inputService;
        private readonly GameContext _game;
        private const float TurnTime = 0.07f;
        private float _turnVelocity;

        public PlayerRotationSystem(IInputService inputService, GameContext game)
        {
            _inputService = inputService;
            _game = game;
        }
        
        public void Update()
        {
            var player = _game.PlayerEntity;
            
            if (!player.IsCanMove || player.IsDead)
                return;

            var playerRotation = player.Rotation.Value;
            var inputVector = _inputService.InputDirection;
           
            if(inputVector.sqrMagnitude < 0.01f)
                return;
                
            var angle = Mathf.Atan2(inputVector.x, inputVector.z) * Mathf.Rad2Deg;
            var currentY = playerRotation.eulerAngles.y;
            var smoothAngle = Mathf.SmoothDampAngle(currentY, angle, ref _turnVelocity, TurnTime);
            var rotation = Quaternion.Euler(0f, smoothAngle, 0f);
            player.ReplaceRotation(rotation);
        }
    }
}