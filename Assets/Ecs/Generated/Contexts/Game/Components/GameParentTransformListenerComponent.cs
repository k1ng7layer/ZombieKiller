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
	public ParentTransformListenerComponent ParentTransformListener { get { return (ParentTransformListenerComponent)GetComponent(GameComponentsLookup.ParentTransformListener); } }
	public bool HasParentTransformListener { get { return HasComponent(GameComponentsLookup.ParentTransformListener); } }

	public void AddParentTransformListener()
	{
		var index = GameComponentsLookup.ParentTransformListener;
		var component = (ParentTransformListenerComponent)CreateComponent(index, typeof(ParentTransformListenerComponent));
		AddComponent(index, component);
	}

	public void ReplaceParentTransformListener()
	{
		ReplaceComponent(GameComponentsLookup.ParentTransformListener, ParentTransformListener);
	}

	public void RemoveParentTransformListener()
	{
		RemoveComponent(GameComponentsLookup.ParentTransformListener);
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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherParentTransformListener;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> ParentTransformListener
	{
		get
		{
			if (_matcherParentTransformListener == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.ParentTransformListener);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherParentTransformListener = matcher;
			}

			return _matcherParentTransformListener;
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
	public System.IDisposable SubscribeParentTransform(OnGameParentTransform value, bool invokeOnSubscribe = true)
	{
		var componentListener = HasParentTransformListener
			? ParentTransformListener
			: (ParentTransformListenerComponent)CreateComponent(GameComponentsLookup.ParentTransformListener, typeof(ParentTransformListenerComponent));
		componentListener.Delegate += value;
		ReplaceComponent(GameComponentsLookup.ParentTransformListener, componentListener);
		if(invokeOnSubscribe && HasComponent(GameComponentsLookup.ParentTransform))
		{
			var component = ParentTransform;
			value(this, component.Value);
		}

		return new JCMG.EntitasRedux.Events.EventDisposable<OnGameParentTransform>(CreationIndex, value, UnsubscribeParentTransform);
	}

	private void UnsubscribeParentTransform(int creationIndex, OnGameParentTransform value)
	{
		if(!IsEnabled || CreationIndex != creationIndex)
			return;

		var index = GameComponentsLookup.ParentTransformListener;
		var component = ParentTransformListener;
		component.Delegate -= value;
		if (ParentTransformListener.IsEmpty)
		{
			RemoveComponent(index);
		}
		else
		{
			ReplaceComponent(index, component);
		}
	}
}
