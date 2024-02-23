using CleverCrow.Fluid.BTs.TaskParents.Composites;
using CleverCrow.Fluid.BTs.Tasks;

namespace Game.Models.Ai.Utils.TaskParents.Composites
{
	public class Repeater : CompositeBase
	{
		public override string IconPath { get; } = $"{PACKAGE_ROOT}/RightArrow.png";

		protected override TaskStatus OnUpdate()
		{
			for (var i = 0; i < Children.Count; i++)
			{
				var child = Children[i];

				if (i < ChildIndex)
					child.Reset();

				var status = child.Update();
				if (status == TaskStatus.Success)
					continue;

				if (status == TaskStatus.Continue)
					ChildIndex = i;
				return status;
			}

			return TaskStatus.Success;
		}
	}
}