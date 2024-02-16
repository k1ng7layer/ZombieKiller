using Ecs.Commands.Command.Input;
using JCMG.EntitasRedux.Commands;

namespace Ecs.Commands.Systems.Input
{
    //[Install(ExecutionType.Game, ExecutionPriority.Normal, 150, nameof(EFeatures.Input))]
    public class PointerDownSystem : ForEachCommandUpdateSystem<PointerDownCommand>
    {
        private readonly GameContext _game;
        
        public PointerDownSystem(
            ICommandBuffer commandBuffer,
            GameContext game
        ) : base(commandBuffer)
        {
            _game = game;
        }

        protected override void Execute(ref PointerDownCommand command)
        {
            var camera = _game.CameraEntity;

            camera.IsCameraMove = true;
        }
    }
}