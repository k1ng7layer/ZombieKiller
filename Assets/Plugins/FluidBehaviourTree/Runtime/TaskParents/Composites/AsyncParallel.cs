using CleverCrow.Fluid.BTs.Tasks;

namespace CleverCrow.Fluid.BTs.TaskParents.Composites
{
    public class AsyncParallel : CompositeBase
    {
        public override string Name => "asyncparallel";

        public override string IconPath { get; } = $"{PACKAGE_ROOT}/CompareArrows.png";
        
        
        protected override TaskStatus OnUpdate ()
        {
            var wasContinue = false;
            
            for (var i = 0; i < Children.Count; i++) 
            {
                var child = Children[i];

                var status =                child.Update();
                if (status != TaskStatus.Continue)
                {
                    wasContinue = true;
                    child.Reset();
                }
            }
            if(wasContinue)
                return TaskStatus.Continue;
            
            return TaskStatus.Success;
        }
    }
}