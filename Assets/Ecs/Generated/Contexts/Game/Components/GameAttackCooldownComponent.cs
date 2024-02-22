//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity
{
	public Ecs.Game.Components.UnitParameters.AttackCooldownComponent AttackCooldown { get { return (Ecs.Game.Components.UnitParameters.AttackCooldownComponent)GetComponent(GameComponentsLookup.AttackCooldown); } }
	public bool HasAttackCooldown { get { return HasComponent(GameComponentsLookup.AttackCooldown); } }

	public void AddAttackCooldown(float newValue)
	{
		var index = GameComponentsLookup.AttackCooldown;
		var component = (Ecs.Game.Components.UnitParameters.AttackCooldownComponent)CreateComponent(index, typeof(Ecs.Game.Components.UnitParameters.AttackCooldownComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceAttackCooldown(float newValue)
	{
		var index = GameComponentsLookup.AttackCooldown;
		var component = (Ecs.Game.Components.UnitParameters.AttackCooldownComponent)CreateComponent(index, typeof(Ecs.Game.Components.UnitParameters.AttackCooldownComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyAttackCooldownTo(Ecs.Game.Components.UnitParameters.AttackCooldownComponent copyComponent)
	{
		var index = GameComponentsLookup.AttackCooldown;
		var component = (Ecs.Game.Components.UnitParameters.AttackCooldownComponent)CreateComponent(index, typeof(Ecs.Game.Components.UnitParameters.AttackCooldownComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = copyComponent.Value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveAttackCooldown()
	{
		RemoveComponent(GameComponentsLookup.AttackCooldown);
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
public partial class GameEntity : IAttackCooldownEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher
{
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherAttackCooldown;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> AttackCooldown
	{
		get
		{
			if (_matcherAttackCooldown == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.AttackCooldown);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherAttackCooldown = matcher;
			}

			return _matcherAttackCooldown;
		}
	}
}