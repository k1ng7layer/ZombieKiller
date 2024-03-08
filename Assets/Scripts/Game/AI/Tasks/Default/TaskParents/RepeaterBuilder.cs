using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Trees;
using Game.Models.Ai.Utils;

namespace Game.Models.Ai.Tasks.Default.TaskParents
{
	public class RepeaterBuilder : ATaskParentBuilder
	{
		public override string Name => DefaultTaskNames.REPEATER;

		public override void Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues)
			=> builder.Repeater();
	}
}