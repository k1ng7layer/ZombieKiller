using System;
using Ecs.Commands;
using Game.Services.InputService;
using JCMG.EntitasRedux;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;

namespace Ecs.Game.Systems
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 20, nameof(EFeatures.Input))]
    public class InputSystem : IInitializeSystem, 
        IDisposable
    {
        private readonly IInputService _inputService;
        private readonly ICommandBuffer _commandBuffer;
        private readonly GameContext _game;

        public InputSystem(IInputService inputService, ICommandBuffer commandBuffer, GameContext game)
        {
            _inputService = inputService;
            _commandBuffer = commandBuffer;
            _game = game;
        }
        
        public void Initialize()
        {
            _inputService.BasicAttackPressed += OnBasicAttackPressed;
        }
        
        public void Dispose()
        {
            _inputService.BasicAttackPressed -= OnBasicAttackPressed;
        }

        private void OnBasicAttackPressed()
        {
            var player = _game.PlayerEntity;
            
            _commandBuffer.StartPerformingAttack(player.Uid.Value);
        }
    }
}