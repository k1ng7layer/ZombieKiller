using Ecs.Commands.Command;
using JCMG.EntitasRedux.Commands;

namespace Ecs.Commands.Systems
{
    public class DropItemSystem : ForEachCommandUpdateSystem<DropItemCommand>
    {
        public DropItemSystem(ICommandBuffer commandBuffer) : base(commandBuffer)
        {
            
        }

        protected override void Execute(ref DropItemCommand command)
        {
            
        }
    }
}