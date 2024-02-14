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
	public Ecs.Game.Components.TimeComponent Time { get { return (Ecs.Game.Components.TimeComponent)GetComponent(GameComponentsLookup.Time); } }
	public bool HasTime { get { return HasComponent(GameComponentsLookup.Time); } }

	public void AddTime(float newValue)
	{
		var index = GameComponentsLookup.Time;
		var component = (Ecs.Game.Components.TimeComponent)CreateComponent(index, typeof(Ecs.Game.Components.TimeComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceTime(float newValue)
	{
		var index = GameComponentsLookup.Time;
		var component = (Ecs.Game.Components.TimeComponent)CreateComponent(index, typeof(Ecs.Game.Components.TimeComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyTimeTo(Ecs.Game.Components.TimeComponent copyComponent)
	{
		var index = GameComponentsLookup.Time;
		var component = (Ecs.Game.Components.TimeComponent)CreateComponent(index, typeof(Ecs.Game.Components.TimeComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = copyComponent.Value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveTime()
	{
		RemoveComponent(GameComponentsLookup.Time);
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
public partial class GameEntity : ITimeEntity { }

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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherTime;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> Time
	{
		get
		{
			if (_matcherTime == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.Time);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherTime = matcher;
			}

			return _matcherTime;
		}
	}
}
