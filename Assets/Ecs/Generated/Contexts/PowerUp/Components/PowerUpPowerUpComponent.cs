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
	public Ecs.PowerUp.Components.PowerUpComponent PowerUp { get { return (Ecs.PowerUp.Components.PowerUpComponent)GetComponent(PowerUpComponentsLookup.PowerUp); } }
	public bool HasPowerUp { get { return HasComponent(PowerUpComponentsLookup.PowerUp); } }

	public void AddPowerUp(int newId)
	{
		var index = PowerUpComponentsLookup.PowerUp;
		var component = (Ecs.PowerUp.Components.PowerUpComponent)CreateComponent(index, typeof(Ecs.PowerUp.Components.PowerUpComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Id = newId;
		#endif
		AddComponent(index, component);
	}

	public void ReplacePowerUp(int newId)
	{
		var index = PowerUpComponentsLookup.PowerUp;
		var component = (Ecs.PowerUp.Components.PowerUpComponent)CreateComponent(index, typeof(Ecs.PowerUp.Components.PowerUpComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Id = newId;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyPowerUpTo(Ecs.PowerUp.Components.PowerUpComponent copyComponent)
	{
		var index = PowerUpComponentsLookup.PowerUp;
		var component = (Ecs.PowerUp.Components.PowerUpComponent)CreateComponent(index, typeof(Ecs.PowerUp.Components.PowerUpComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Id = copyComponent.Id;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemovePowerUp()
	{
		RemoveComponent(PowerUpComponentsLookup.PowerUp);
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
public partial class PowerUpEntity : IPowerUpEntity { }

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
	static JCMG.EntitasRedux.IMatcher<PowerUpEntity> _matcherPowerUp;

	public static JCMG.EntitasRedux.IMatcher<PowerUpEntity> PowerUp
	{
		get
		{
			if (_matcherPowerUp == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<PowerUpEntity>)JCMG.EntitasRedux.Matcher<PowerUpEntity>.AllOf(PowerUpComponentsLookup.PowerUp);
				matcher.ComponentNames = PowerUpComponentsLookup.ComponentNames;
				_matcherPowerUp = matcher;
			}

			return _matcherPowerUp;
		}
	}
}