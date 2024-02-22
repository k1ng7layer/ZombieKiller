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
	public DestinationPositionListenerComponent DestinationPositionListener { get { return (DestinationPositionListenerComponent)GetComponent(GameComponentsLookup.DestinationPositionListener); } }
	public bool HasDestinationPositionListener { get { return HasComponent(GameComponentsLookup.DestinationPositionListener); } }

	public void AddDestinationPositionListener()
	{
		var index = GameComponentsLookup.DestinationPositionListener;
		var component = (DestinationPositionListenerComponent)CreateComponent(index, typeof(DestinationPositionListenerComponent));
		AddComponent(index, component);
	}

	public void ReplaceDestinationPositionListener()
	{
		ReplaceComponent(GameComponentsLookup.DestinationPositionListener, DestinationPositionListener);
	}

	public void RemoveDestinationPositionListener()
	{
		RemoveComponent(GameComponentsLookup.DestinationPositionListener);
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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherDestinationPositionListener;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> DestinationPositionListener
	{
		get
		{
			if (_matcherDestinationPositionListener == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.DestinationPositionListener);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherDestinationPositionListener = matcher;
			}

			return _matcherDestinationPositionListener;
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
	public System.IDisposable SubscribeDestinationPosition(OnGameDestinationPosition value, bool invokeOnSubscribe = true)
	{
		var componentListener = HasDestinationPositionListener
			? DestinationPositionListener
			: (DestinationPositionListenerComponent)CreateComponent(GameComponentsLookup.DestinationPositionListener, typeof(DestinationPositionListenerComponent));
		componentListener.Delegate += value;
		ReplaceComponent(GameComponentsLookup.DestinationPositionListener, componentListener);
		if(invokeOnSubscribe && HasComponent(GameComponentsLookup.DestinationPosition))
		{
			var component = DestinationPosition;
			value(this, component.Value);
		}

		return new JCMG.EntitasRedux.Events.EventDisposable<OnGameDestinationPosition>(CreationIndex, value, UnsubscribeDestinationPosition);
	}

	private void UnsubscribeDestinationPosition(int creationIndex, OnGameDestinationPosition value)
	{
		if(!IsEnabled || CreationIndex != creationIndex)
			return;

		var index = GameComponentsLookup.DestinationPositionListener;
		var component = DestinationPositionListener;
		component.Delegate -= value;
		if (DestinationPositionListener.IsEmpty)
		{
			RemoveComponent(index);
		}
		else
		{
			ReplaceComponent(index, component);
		}
	}
}