using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Trees;

namespace Game.Models.Ai.Tasks.Default.TaskParents
{
	public class SelectorRandomBuilder : ATaskParentBuilder
	{
		public override string Name => DefaultTaskNames.SELECTOR_RANDOM;

		public override void Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues)
			=> builder.SelectorRandom();
	}
}