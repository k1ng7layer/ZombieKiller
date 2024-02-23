//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class PowerUpEntity
{
	static readonly Ecs.Common.Components.DestroyedComponent DestroyedComponent = new Ecs.Common.Components.DestroyedComponent();

	public bool IsDestroyed
	{
		get { return HasComponent(PowerUpComponentsLookup.Destroyed); }
		set
		{
			if (value != IsDestroyed)
			{
				var index = PowerUpComponentsLookup.Destroyed;
				if (value)
				{
					var componentPool = GetComponentPool(index);
					var component = componentPool.Count > 0
							? componentPool.Pop()
							: DestroyedComponent;

					AddComponent(index, component);
				}
				else
				{
					RemoveComponent(index);
				}
			}
		}
	}
}

//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class PowerUpEntity : IDestroyedEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class PowerUpMatcher
{
	static JCMG.EntitasRedux.IMatcher<PowerUpEntity> _matcherDestroyed;

	public static JCMG.EntitasRedux.IMatcher<PowerUpEntity> Destroyed
	{
		get
		{
			if (_matcherDestroyed == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<PowerUpEntity>)JCMG.EntitasRedux.Matcher<PowerUpEntity>.AllOf(PowerUpComponentsLookup.Destroyed);
				matcher.ComponentNames = PowerUpComponentsLookup.ComponentNames;
				_matcherDestroyed = matcher;
			}

			return _matcherDestroyed;
		}
	}
}