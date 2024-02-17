//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using JCMG.EntitasRedux;

public sealed class DeadEventSystem : JCMG.EntitasRedux.ReactiveSystem<GameEntity>
{

	public DeadEventSystem(IContext<GameEntity> context) : base(context)
	{
	}

	protected override JCMG.EntitasRedux.ICollector<GameEntity> GetTrigger(JCMG.EntitasRedux.IContext<GameEntity> context)
	{
		return new SlimCollector<GameEntity>(context, GameComponentsLookup.Dead, EventType.Added);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.IsDead && entity.HasDeadListener;
	}

	protected override void Execute(System.Collections.Generic.IEnumerable<GameEntity> entities)
	{
		foreach (var e in entities)
		{
			
			e.DeadListener.Invoke(e);
		}
	}
}
