//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts : JCMG.EntitasRedux.IContexts
{
	#if UNITY_EDITOR

	static Contexts()
	{
		UnityEditor.EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
	}

	/// <summary>
	/// Invoked when the Unity Editor has a <see cref="UnityEditor.PlayModeStateChange"/> change.
	/// </summary>
	private static void OnPlayModeStateChanged(UnityEditor.PlayModeStateChange playModeStateChange)
	{
		// When entering edit-mode, reset all static state so that it does not interfere with the
		// next play-mode session.
		if (playModeStateChange == UnityEditor.PlayModeStateChange.EnteredEditMode)
		{
			_sharedInstance = null;
		}
	}

	#endif

	public static Contexts SharedInstance
	{
		get
		{
			if (_sharedInstance == null)
			{
				_sharedInstance = new Contexts();
			}

			return _sharedInstance;
		}
		set	{ _sharedInstance = value; }
	}

	static Contexts _sharedInstance;

	public GameContext Game { get; set; }
	public InputContext Input { get; set; }

	public JCMG.EntitasRedux.IContext[] AllContexts { get { return new JCMG.EntitasRedux.IContext [] { Game, Input }; } }

	private readonly string _name;

	public Contexts(string name = null)
	{
		Game = new GameContext();
		Input = new InputContext();

		_name = name;
		var postConstructors = System.Linq.Enumerable.Where(
			GetType().GetMethods(),
			method => System.Attribute.IsDefined(method, typeof(JCMG.EntitasRedux.PostConstructorAttribute))
		);

		foreach (var postConstructor in postConstructors)
		{
			postConstructor.Invoke(this, null);
		}
	}

	public void Reset()
	{
		var contexts = AllContexts;
		for (int i = 0; i < contexts.Length; i++)
		{
			contexts[i].Reset();
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
public partial class Contexts
{
	public const string Uid = "Uid";

	[JCMG.EntitasRedux.PostConstructor]
	public void InitializeEntityIndices()
	{
		Game.AddEntityIndex(new JCMG.EntitasRedux.PrimaryEntityIndex<GameEntity, Ecs.Extensions.UidGenerator.Uid>(
			GameComponentsLookup.Uid,
			Game.GetGroup(GameMatcher.Uid),
			(e, c) => ((Ecs.Common.Components.UidComponent)c).Value));
		Input.AddEntityIndex(new JCMG.EntitasRedux.PrimaryEntityIndex<InputEntity, Ecs.Extensions.UidGenerator.Uid>(
			InputComponentsLookup.Uid,
			Input.GetGroup(InputMatcher.Uid),
			(e, c) => ((Ecs.Common.Components.UidComponent)c).Value));
	}
}

public static class ContextsExtensions
{
	public static GameEntity GetEntityWithUid(this GameContext context, Ecs.Extensions.UidGenerator.Uid Value)
	{
		return ((JCMG.EntitasRedux.PrimaryEntityIndex<GameEntity, Ecs.Extensions.UidGenerator.Uid>)context.GetEntityIndex(GameComponentsLookup.Uid)).GetEntity(Value);
	}

	public static InputEntity GetEntityWithUid(this InputContext context, Ecs.Extensions.UidGenerator.Uid Value)
	{
		return ((JCMG.EntitasRedux.PrimaryEntityIndex<InputEntity, Ecs.Extensions.UidGenerator.Uid>)context.GetEntityIndex(InputComponentsLookup.Uid)).GetEntity(Value);
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
public partial class Contexts {

#if (!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)

	[JCMG.EntitasRedux.PostConstructor]
	public void InitializeContextObservers() {
		if (!UnityEngine.Application.isPlaying)
			return;

		UnityEngine.Transform parent = null;

		if (!string.IsNullOrEmpty(_name))
		{
			var go = new UnityEngine.GameObject(_name);
			UnityEngine.Object.DontDestroyOnLoad(go);
			parent = go.transform;
		}

		try
		{
			CreateContextObserver(Game, parent);
			CreateContextObserver(Input, parent);
		}
		catch(System.Exception)
		{
		}
	}

	public void CreateContextObserver(JCMG.EntitasRedux.IContext context, UnityEngine.Transform parent) {
		var observer = new JCMG.EntitasRedux.VisualDebugging.ContextObserver(context, parent);
		UnityEngine.Object.DontDestroyOnLoad(observer.GameObject);
	}

#endif
}
