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
	public GameActiveRemovedListenerComponent GameActiveRemovedListener { get { return (GameActiveRemovedListenerComponent)GetComponent(GameComponentsLookup.GameActiveRemovedListener); } }
	public bool HasGameActiveRemovedListener { get { return HasComponent(GameComponentsLookup.GameActiveRemovedListener); } }

	public void AddGameActiveRemovedListener()
	{
		var index = GameComponentsLookup.GameActiveRemovedListener;
		var component = (GameActiveRemovedListenerComponent)CreateComponent(index, typeof(GameActiveRemovedListenerComponent));
		AddComponent(index, component);
	}

	public void ReplaceGameActiveRemovedListener()
	{
		ReplaceComponent(GameComponentsLookup.GameActiveRemovedListener, GameActiveRemovedListener);
	}

	public void RemoveGameActiveRemovedListener()
	{
		RemoveComponent(GameComponentsLookup.GameActiveRemovedListener);
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
public sealed partial class GameMatcher
{
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherGameActiveRemovedListener;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> GameActiveRemovedListener
	{
		get
		{
			if (_matcherGameActiveRemovedListener == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameActiveRemovedListener);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherGameActiveRemovedListener = matcher;
			}

			return _matcherGameActiveRemovedListener;
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
public partial class GameEntity
{
	public System.IDisposable SubscribeActiveRemoved(OnGameActiveRemoved value, bool invokeOnSubscribe = false)
	{
		var componentListener = HasGameActiveRemovedListener
			? GameActiveRemovedListener
			: (GameActiveRemovedListenerComponent)CreateComponent(GameComponentsLookup.GameActiveRemovedListener, typeof(GameActiveRemovedListenerComponent));
		componentListener.Delegate += value;
		ReplaceComponent(GameComponentsLookup.GameActiveRemovedListener, componentListener);
		if(invokeOnSubscribe && !HasComponent(GameComponentsLookup.Active))
		{
			value(this);
		}

		return new JCMG.EntitasRedux.Events.EventDisposable<OnGameActiveRemoved>(CreationIndex, value, UnsubscribeActiveRemoved);
	}

	private void UnsubscribeActiveRemoved(int creationIndex, OnGameActiveRemoved value)
	{
		if(!IsEnabled || CreationIndex != creationIndex)
			return;

		var index = GameComponentsLookup.GameActiveRemovedListener;
		var component = GameActiveRemovedListener;
		component.Delegate -= value;
		if (GameActiveRemovedListener.IsEmpty)
		{
			RemoveComponent(index);
		}
		else
		{
			ReplaceComponent(index, component);
		}
	}
}