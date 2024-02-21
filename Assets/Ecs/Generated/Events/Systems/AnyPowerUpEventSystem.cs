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

public sealed class AnyPowerUpEventSystem : JCMG.EntitasRedux.ReactiveSystem<PowerUpEntity>
{
	readonly JCMG.EntitasRedux.IGroup<PowerUpEntity> _listeners;

	public AnyPowerUpEventSystem(IContext<PowerUpEntity> context) : base(context)
	{
		_listeners = context.GetGroup(PowerUpMatcher.AnyPowerUpListener);
	}

	protected override JCMG.EntitasRedux.ICollector<PowerUpEntity> GetTrigger(JCMG.EntitasRedux.IContext<PowerUpEntity> context)
	{
		return new SlimCollector<PowerUpEntity>(context, PowerUpComponentsLookup.PowerUp, EventType.Added);
	}

	protected override bool Filter(PowerUpEntity entity)
	{
		return entity.HasPowerUp;
	}

	protected override void Execute(System.Collections.Generic.IEnumerable<PowerUpEntity> entities)
	{
		foreach (var e in entities)
		{
			var component = e.PowerUp;
			using(UnityEngine.Pool.ListPool<PowerUpEntity>.Get(out var buffer))
			{
				_listeners.GetEntities(buffer);
				foreach (var listenerEntity in buffer)
					listenerEntity.AnyPowerUpListener.Invoke(e, component.Id);
			}
		}
	}
}
