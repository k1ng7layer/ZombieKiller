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
	public MovingListenerComponent MovingListener { get { return (MovingListenerComponent)GetComponent(GameComponentsLookup.MovingListener); } }
	public bool HasMovingListener { get { return HasComponent(GameComponentsLookup.MovingListener); } }

	public void AddMovingListener()
	{
		var index = GameComponentsLookup.MovingListener;
		var component = (MovingListenerComponent)CreateComponent(index, typeof(MovingListenerComponent));
		AddComponent(index, component);
	}

	public void ReplaceMovingListener()
	{
		ReplaceComponent(GameComponentsLookup.MovingListener, MovingListener);
	}

	public void RemoveMovingListener()
	{
		RemoveComponent(GameComponentsLookup.MovingListener);
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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherMovingListener;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> MovingListener
	{
		get
		{
			if (_matcherMovingListener == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.MovingListener);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherMovingListener = matcher;
			}

			return _matcherMovingListener;
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
	public System.IDisposable SubscribeMoving(OnGameMoving value, bool invokeOnSubscribe = true)
	{
		var componentListener = HasMovingListener
			? MovingListener
			: (MovingListenerComponent)CreateComponent(GameComponentsLookup.MovingListener, typeof(MovingListenerComponent));
		componentListener.Delegate += value;
		ReplaceComponent(GameComponentsLookup.MovingListener, componentListener);
		if(invokeOnSubscribe && HasComponent(GameComponentsLookup.Moving))
		{
			value(this);
		}

		return new JCMG.EntitasRedux.Events.EventDisposable<OnGameMoving>(CreationIndex, value, UnsubscribeMoving);
	}

	private void UnsubscribeMoving(int creationIndex, OnGameMoving value)
	{
		if(!IsEnabled || CreationIndex != creationIndex)
			return;

		var index = GameComponentsLookup.MovingListener;
		var component = MovingListener;
		component.Delegate -= value;
		if (MovingListener.IsEmpty)
		{
			RemoveComponent(index);
		}
		else
		{
			ReplaceComponent(index, component);
		}
	}
}