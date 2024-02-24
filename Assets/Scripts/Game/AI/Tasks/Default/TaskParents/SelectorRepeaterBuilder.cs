using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Trees;
using Game.Models.Ai.Utils;

namespace Game.Models.Ai.Tasks.Default.TaskParents
{
	public class SelectorRepeaterBuilder : ATaskParentBuilder
	{
		public override string Name => DefaultTaskNames.SELECTOR_REPEATER;

		public override void Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues)
			=> builder.SelectorRepeater();
	}
}