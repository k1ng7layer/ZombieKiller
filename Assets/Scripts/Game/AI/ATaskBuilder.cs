using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Trees;

namespace Game.AI
{
	public abstract class ATaskBuilder : ITaskBuilder
	{
		public abstract string Name { get; }

		public abstract void Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues);

		public virtual void End(BehaviorTreeBuilder builder)
		{
		}
	}
}