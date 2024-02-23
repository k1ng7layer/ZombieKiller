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
	public Ecs.Game.Components.UnitLevelComponent UnitLevel { get { return (Ecs.Game.Components.UnitLevelComponent)GetComponent(GameComponentsLookup.UnitLevel); } }
	public bool HasUnitLevel { get { return HasComponent(GameComponentsLookup.UnitLevel); } }

	public void AddUnitLevel(int newValue)
	{
		var index = GameComponentsLookup.UnitLevel;
		var component = (Ecs.Game.Components.UnitLevelComponent)CreateComponent(index, typeof(Ecs.Game.Components.UnitLevelComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceUnitLevel(int newValue)
	{
		var index = GameComponentsLookup.UnitLevel;
		var component = (Ecs.Game.Components.UnitLevelComponent)CreateComponent(index, typeof(Ecs.Game.Components.UnitLevelComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyUnitLevelTo(Ecs.Game.Components.UnitLevelComponent copyComponent)
	{
		var index = GameComponentsLookup.UnitLevel;
		var component = (Ecs.Game.Components.UnitLevelComponent)CreateComponent(index, typeof(Ecs.Game.Components.UnitLevelComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = copyComponent.Value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveUnitLevel()
	{
		RemoveComponent(GameComponentsLookup.UnitLevel);
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
public partial class GameEntity : IUnitLevelEntity { }

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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherUnitLevel;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> UnitLevel
	{
		get
		{
			if (_matcherUnitLevel == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.UnitLevel);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherUnitLevel = matcher;
			}

			return _matcherUnitLevel;
		}
	}
}