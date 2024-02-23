using System.Collections.Generic;
using Game.AI;

namespace Game.Models.Ai.Impls
{
	public class AiTaskBuildersLibrary : IAiTaskBuildersLibrary
	{
		private readonly List<ITaskBuilder> _taskBuilders;

		public AiTaskBuildersLibrary(List<ITaskBuilder> taskBuilders)
		{
			_taskBuilders = taskBuilders;
		}

		public ITaskBuilder Get(string name)
		{
			for (var i = 0; i < _taskBuilders.Count; i++)
			{
				var taskBuilder = _taskBuilders[i];
				if (taskBuilder.Name == name)
					return taskBuilder;
			}

			throw new System.Exception($"[{nameof(AiTaskBuildersLibrary)}] No task builder with name {name}");
		}
	}
}