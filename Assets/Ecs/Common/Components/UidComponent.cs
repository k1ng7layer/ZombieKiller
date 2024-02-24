using Ecs.Extensions.UidGenerator;
using JCMG.EntitasRedux;

namespace Ecs.Common.Components
{
    [Game]
    [Input]
    [PowerUp]
    public class UidComponent : IComponent
    {
        [PrimaryEntityIndex] public Uid Value;
        
        public override string ToString() => Value.ToString();
    }
}