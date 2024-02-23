using CleverCrow.Fluid.BTs.Trees;
using Game.AI;

namespace Game.Models.Ai.Tasks.Default.TaskParents
{
	public abstract class ATaskParentBuilder : ATaskBuilder
	{
		public override void End(BehaviorTreeBuilder builder)
			=> builder.End();
	}
}