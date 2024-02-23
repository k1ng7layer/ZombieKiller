using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;

namespace Game.Models.Ai.Utils.Tasks
{
    public class SkipTicksAction : ActionBase
    {
        private readonly int _ticksToSkip;
        private int _skippedTicks;
        
        public override string IconPath { get; } = $"{PACKAGE_ROOT}/Hourglass.png";

        public SkipTicksAction(int ticksToSkip)
        {
            _ticksToSkip = ticksToSkip;
        }

        protected override void OnStart()
        {
            _skippedTicks = 0;
        }

        protected override TaskStatus OnUpdate()
        {
            _skippedTicks++;
            if (_skippedTicks < _ticksToSkip - 1)
                return TaskStatus.Continue;

            return TaskStatus.Success;
        }
    }
}