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
	public Ecs.Game.Components.PortalComponent Portal { get { return (Ecs.Game.Components.PortalComponent)GetComponent(GameComponentsLookup.Portal); } }
	public bool HasPortal { get { return HasComponent(GameComponentsLookup.Portal); } }

	public void AddPortal(Game.Utils.EPortalDestination newPortalDestination)
	{
		var index = GameComponentsLookup.Portal;
		var component = (Ecs.Game.Components.PortalComponent)CreateComponent(index, typeof(Ecs.Game.Components.PortalComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.PortalDestination = newPortalDestination;
		#endif
		AddComponent(index, component);
	}

	public void ReplacePortal(Game.Utils.EPortalDestination newPortalDestination)
	{
		var index = GameComponentsLookup.Portal;
		var component = (Ecs.Game.Components.PortalComponent)CreateComponent(index, typeof(Ecs.Game.Components.PortalComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.PortalDestination = newPortalDestination;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyPortalTo(Ecs.Game.Components.PortalComponent copyComponent)
	{
		var index = GameComponentsLookup.Portal;
		var component = (Ecs.Game.Components.PortalComponent)CreateComponent(index, typeof(Ecs.Game.Components.PortalComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.PortalDestination = copyComponent.PortalDestination;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemovePortal()
	{
		RemoveComponent(GameComponentsLookup.Portal);
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
public partial class GameEntity : IPortalEntity { }

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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherPortal;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> Portal
	{
		get
		{
			if (_matcherPortal == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.Portal);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherPortal = matcher;
			}

			return _matcherPortal;
		}
	}
}