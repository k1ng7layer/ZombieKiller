using CleverCrow.Fluid.BTs.TaskParents.Composites;
using CleverCrow.Fluid.BTs.Tasks;

namespace Game.Models.Ai.Utils.TaskParents.Composites
{
	public class SelectorRepeater : CompositeBase
	{
		public override string IconPath { get; } = $"{PACKAGE_ROOT}/LinearScale.png";

		protected override TaskStatus OnUpdate()
		{
			for (var i = 0; i < Children.Count; i++)
			{
				var child = Children[i];

				if (i < ChildIndex)
					child.Reset();

				var taskStatus = child.Update();
				if (taskStatus == TaskStatus.Failure)
					continue;

				ChildIndex = i;
				return taskStatus;
			}

			return TaskStatus.Failure;
		}
	}
}