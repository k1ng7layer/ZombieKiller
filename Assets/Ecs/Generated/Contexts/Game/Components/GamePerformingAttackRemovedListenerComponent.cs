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
	public PerformingAttackRemovedListenerComponent PerformingAttackRemovedListener { get { return (PerformingAttackRemovedListenerComponent)GetComponent(GameComponentsLookup.PerformingAttackRemovedListener); } }
	public bool HasPerformingAttackRemovedListener { get { return HasComponent(GameComponentsLookup.PerformingAttackRemovedListener); } }

	public void AddPerformingAttackRemovedListener()
	{
		var index = GameComponentsLookup.PerformingAttackRemovedListener;
		var component = (PerformingAttackRemovedListenerComponent)CreateComponent(index, typeof(PerformingAttackRemovedListenerComponent));
		AddComponent(index, component);
	}

	public void ReplacePerformingAttackRemovedListener()
	{
		ReplaceComponent(GameComponentsLookup.PerformingAttackRemovedListener, PerformingAttackRemovedListener);
	}

	public void RemovePerformingAttackRemovedListener()
	{
		RemoveComponent(GameComponentsLookup.PerformingAttackRemovedListener);
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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherPerformingAttackRemovedListener;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> PerformingAttackRemovedListener
	{
		get
		{
			if (_matcherPerformingAttackRemovedListener == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.PerformingAttackRemovedListener);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherPerformingAttackRemovedListener = matcher;
			}

			return _matcherPerformingAttackRemovedListener;
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
	public System.IDisposable SubscribePerformingAttackRemoved(OnGamePerformingAttackRemoved value, bool invokeOnSubscribe = false)
	{
		var componentListener = HasPerformingAttackRemovedListener
			? PerformingAttackRemovedListener
			: (PerformingAttackRemovedListenerComponent)CreateComponent(GameComponentsLookup.PerformingAttackRemovedListener, typeof(PerformingAttackRemovedListenerComponent));
		componentListener.Delegate += value;
		ReplaceComponent(GameComponentsLookup.PerformingAttackRemovedListener, componentListener);
		if(invokeOnSubscribe && !HasComponent(GameComponentsLookup.PerformingAttack))
		{
			value(this);
		}

		return new JCMG.EntitasRedux.Events.EventDisposable<OnGamePerformingAttackRemoved>(CreationIndex, value, UnsubscribePerformingAttackRemoved);
	}

	private void UnsubscribePerformingAttackRemoved(int creationIndex, OnGamePerformingAttackRemoved value)
	{
		if(!IsEnabled || CreationIndex != creationIndex)
			return;

		var index = GameComponentsLookup.PerformingAttackRemovedListener;
		var component = PerformingAttackRemovedListener;
		component.Delegate -= value;
		if (PerformingAttackRemovedListener.IsEmpty)
		{
			RemoveComponent(index);
		}
		else
		{
			ReplaceComponent(index, component);
		}
	}
}