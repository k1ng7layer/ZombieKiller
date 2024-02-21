//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using JCMG.EntitasRedux;

public static class PowerUpComponentsLookup
{
	public const int AnyPlayerBuffListener = 0;
	public const int AnyPowerUpListener = 1;
	public const int Destroyed = 2;
	public const int Uid = 3;
	public const int Active = 4;
	public const int Owner = 5;
	public const int Timer = 6;
	public const int LifeTime = 7;
	public const int PlayerBuff = 8;
	public const int PlayerPowerUp = 9;
	public const int PowerUp = 10;
	public const int Resource = 11;
	public const int PlayerBuffRemovedListener = 12;
	public const int PowerUpActiveListener = 13;
	public const int PowerUpActiveRemovedListener = 14;
	public const int PowerUpDestroyedListener = 15;
	public const int PowerUpListener = 16;
	public const int PowerUpRemovedListener = 17;
	public const int PowerUpTimerListener = 18;
	public const int ResourceListener = 19;

	public const int TotalComponents = 20;

	public static readonly string[] ComponentNames =
	{
		"AnyPlayerBuffListener",
		"AnyPowerUpListener",
		"Destroyed",
		"Uid",
		"Active",
		"Owner",
		"Timer",
		"LifeTime",
		"PlayerBuff",
		"PlayerPowerUp",
		"PowerUp",
		"Resource",
		"PlayerBuffRemovedListener",
		"PowerUpActiveListener",
		"PowerUpActiveRemovedListener",
		"PowerUpDestroyedListener",
		"PowerUpListener",
		"PowerUpRemovedListener",
		"PowerUpTimerListener",
		"ResourceListener"
	};

	public static readonly System.Type[] ComponentTypes =
	{
		typeof(AnyPlayerBuffListenerComponent),
		typeof(AnyPowerUpListenerComponent),
		typeof(Ecs.Common.Components.DestroyedComponent),
		typeof(Ecs.Common.Components.UidComponent),
		typeof(Ecs.Game.Components.ActiveComponent),
		typeof(Ecs.Game.Components.OwnerComponent),
		typeof(Ecs.Game.Components.TimerComponent),
		typeof(Ecs.PowerUp.Components.LifeTimeComponent),
		typeof(Ecs.PowerUp.Components.PlayerBuffComponent),
		typeof(Ecs.PowerUp.Components.PlayerPowerUpComponent),
		typeof(Ecs.PowerUp.Components.PowerUpComponent),
		typeof(Ecs.PowerUp.Components.ResourceComponent),
		typeof(PlayerBuffRemovedListenerComponent),
		typeof(PowerUpActiveListenerComponent),
		typeof(PowerUpActiveRemovedListenerComponent),
		typeof(PowerUpDestroyedListenerComponent),
		typeof(PowerUpListenerComponent),
		typeof(PowerUpRemovedListenerComponent),
		typeof(PowerUpTimerListenerComponent),
		typeof(ResourceListenerComponent)
	};

	public static readonly Dictionary<Type, int> ComponentTypeToIndex = new Dictionary<Type, int>
	{
		{ typeof(AnyPlayerBuffListenerComponent), 0 },
		{ typeof(AnyPowerUpListenerComponent), 1 },
		{ typeof(Ecs.Common.Components.DestroyedComponent), 2 },
		{ typeof(Ecs.Common.Components.UidComponent), 3 },
		{ typeof(Ecs.Game.Components.ActiveComponent), 4 },
		{ typeof(Ecs.Game.Components.OwnerComponent), 5 },
		{ typeof(Ecs.Game.Components.TimerComponent), 6 },
		{ typeof(Ecs.PowerUp.Components.LifeTimeComponent), 7 },
		{ typeof(Ecs.PowerUp.Components.PlayerBuffComponent), 8 },
		{ typeof(Ecs.PowerUp.Components.PlayerPowerUpComponent), 9 },
		{ typeof(Ecs.PowerUp.Components.PowerUpComponent), 10 },
		{ typeof(Ecs.PowerUp.Components.ResourceComponent), 11 },
		{ typeof(PlayerBuffRemovedListenerComponent), 12 },
		{ typeof(PowerUpActiveListenerComponent), 13 },
		{ typeof(PowerUpActiveRemovedListenerComponent), 14 },
		{ typeof(PowerUpDestroyedListenerComponent), 15 },
		{ typeof(PowerUpListenerComponent), 16 },
		{ typeof(PowerUpRemovedListenerComponent), 17 },
		{ typeof(PowerUpTimerListenerComponent), 18 },
		{ typeof(ResourceListenerComponent), 19 }
	};

	/// <summary>
	/// Returns a component index based on the passed <paramref name="component"/> type; where an index cannot be found
	/// -1 will be returned instead.
	/// </summary>
	/// <param name="component"></param>
	public static int GetComponentIndex(IComponent component)
	{
		return GetComponentIndex(component.GetType());
	}

	/// <summary>
	/// Returns a component index based on the passed <paramref name="componentType"/>; where an index cannot be found
	/// -1 will be returned instead.
	/// </summary>
	/// <param name="componentType"></param>
	public static int GetComponentIndex(Type componentType)
	{
		return ComponentTypeToIndex.TryGetValue(componentType, out var index) ? index : -1;
	}
}
