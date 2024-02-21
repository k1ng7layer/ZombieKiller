using Ecs.Commands.Generator;
using Ecs.Extensions.UidGenerator;

namespace Ecs.Commands.Command.Attributes
{
    [Command]
    public struct RecalculateUnitAttributesCommand
    {
        public Uid UnitUid;
    }
}