using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Trees;

namespace Game.Models.Ai.Tasks.Default.TaskParents
{
	public class SequenceBuilder : ATaskParentBuilder
	{
		public override string Name => DefaultTaskNames.SEQUENCE;

		public override void Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues)
			=> builder.Sequence();
	}
}