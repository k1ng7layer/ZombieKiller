using System.Threading;
using DG.Tweening;
using Ecs.Commands.Command;
using Ecs.Views;
using Game.Extensions;
using JCMG.EntitasRedux.Commands;
using Plugins.Extensions.InstallerGenerator.Attributes;
using Plugins.Extensions.InstallerGenerator.Enums;
using UniRx.Async;
using UnityEngine;

namespace Ecs.Commands.Systems
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 500, nameof(EFeatures.Common))]
    public class SitDownOnBenchSystem : ForEachCommandUpdateSystem<SitDownOnBenchCommand>
    {
        private readonly GameContext _game;

        public SitDownOnBenchSystem(
            ICommandBuffer commandBuffer, 
            GameContext game
        ) : base(commandBuffer)
        {
            _game = game;
        }

        protected override void Execute(ref SitDownOnBenchCommand command)
        {
            var player = _game.PlayerEntity;
            
            if (player.IsSitting)
                return;
            
            var bench = _game.GetEntityWithUid(command.BenchUid);

            var dirToPlayer = (player.Position.Value - bench.Position.Value);
            
            if (dirToPlayer.magnitude >= 2f)
                return;
            
            var benchForward = bench.Rotation.Value * Vector3.forward;
            var dot = Vector3.Dot(benchForward, dirToPlayer.normalized);
            
            if (dot < 0.5f)
                return;

            player.IsCanMove = false;
            player.IsCanRotate = false;
            player.IsCanAttack = false;
            bench.IsActive = false;
            
            var benchView = (BenchView)bench.Link.View;
            PlayerSit(player, benchView).Forget();
        }

        private async UniTaskVoid PlayerSit(GameEntity player, BenchView benchView)
        {
            var cts = new CancellationTokenSource();
            
            var dir = benchView.Transform.position - player.Position.Value;
            var rot = Quaternion.LookRotation(dir, Vector3.up);
            
            await player.Transform.Value
                .DORotateQuaternion(rot, 0.5f)
                .ToUniTask(cts.Token);
            
            player.ReplaceAutoMovement(0.6f);
            
            await player.Transform.Value
                .DOMove(benchView.StartStandToSit.position, 2f)
                .Play()
                .ToUniTask(cts.Token);

            player.ReplaceAutoMovement(0f);
            
            await player.Transform.Value
                .DORotateQuaternion(benchView.Transform.rotation, 1f)
                .ToUniTask(cts.Token);
            
            player.IsSitting = true;
        }
    }
}