using CleverCrow.Fluid.BTs.Trees;
using Zenject;

namespace Game.AI
{
	public interface IBehaviourTreeFactory : IFactory<GameEntity, IBehaviorTree>
	{
	}
}