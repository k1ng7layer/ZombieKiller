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

public sealed class PowerUpActiveEventSystem : JCMG.EntitasRedux.ReactiveSystem<PowerUpEntity>
{

	public PowerUpActiveEventSystem(IContext<PowerUpEntity> context) : base(context)
	{
	}

	protected override JCMG.EntitasRedux.ICollector<PowerUpEntity> GetTrigger(JCMG.EntitasRedux.IContext<PowerUpEntity> context)
	{
		return new SlimCollector<PowerUpEntity>(context, PowerUpComponentsLookup.Active, EventType.Added);
	}

	protected override bool Filter(PowerUpEntity entity)
	{
		return entity.IsActive && entity.HasPowerUpActiveListener;
	}

	protected override void Execute(System.Collections.Generic.IEnumerable<PowerUpEntity> entities)
	{
		foreach (var e in entities)
		{
			
			e.PowerUpActiveListener.Invoke(e);
		}
	}
}