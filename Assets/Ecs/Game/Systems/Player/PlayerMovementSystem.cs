using Db.Player;
using Ecs.Core.Interfaces;
using Game.Services.InputService;
using JCMG.EntitasRedux;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;
using UnityEngine;

namespace Ecs.Game.Systems.Player
{
    [Install(ExecutionType.Game, ExecutionPriority.High, 1000, nameof(EFeatures.Input))]
    public class PlayerMovementSystem : IUpdateSystem
    {
        private readonly IInputService _inputService;
        private readonly IPlayerSettings _playerSettings;
        private readonly ITimeProvider _timeProvider;
        private readonly GameContext _game;

        public PlayerMovementSystem(
            IInputService inputService, 
            IPlayerSettings playerSettings,
            ITimeProvider timeProvider,
            GameContext game
        )
        {
            _inputService = inputService;
            _game = game;
            _playerSettings = playerSettings;
            _timeProvider = timeProvider;
        }
        
        // public void Fixed()
        // {
        //     var player = _game.PlayerEntity;
        //     
        //     if (!player.IsCanMove || player.IsDead && player.IsPerformingAttack) return;
        //
        //     var input = _inputService.InputDirection.normalized;
        //
        //     var move = input * _playerSettings.BaseMoveSpeed * _timeProvider.FixedDeltaTime;
        //     
        //     player.ReplaceMoveDirection(move);
        // }

        public void Update()
        {
            var player = _game.PlayerEntity;
            
            if (!player.IsCanMove || player.IsDead && player.IsPerformingAttack) return;

            var input = _inputService.InputDirection.normalized;

            var move = input * _playerSettings.BaseMoveSpeed * _timeProvider.DeltaTime;
            
            player.ReplaceMoveDirection(move);
            
            Debug.Log($"PlayerMovementSystem: {move}");
        }
    }
}