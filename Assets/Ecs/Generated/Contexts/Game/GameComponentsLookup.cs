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

public static class GameComponentsLookup
{
	public const int CameraModeListener = 0;
	public const int Destroyed = 1;
	public const int Uid = 2;
	public const int Camera = 3;
	public const int CameraMode = 4;
	public const int CameraMove = 5;
	public const int VirtualCamera = 6;
	public const int CanMove = 7;
	public const int AttackTargets = 8;
	public const int EquippedWeapon = 9;
	public const int PerformingAttack = 10;
	public const int Weapon = 11;
	public const int Dead = 12;
	public const int Enemy = 13;
	public const int HoveredObject = 14;
	public const int Income = 15;
	public const int IncomeTimer = 16;
	public const int Instantiate = 17;
	public const int MoveDirection = 18;
	public const int Owner = 19;
	public const int PlayerCoins = 20;
	public const int Player = 21;
	public const int Position = 22;
	public const int Prefab = 23;
	public const int Rotation = 24;
	public const int Time = 25;
	public const int Transform = 26;
	public const int Health = 27;
	public const int MagicDamage = 28;
	public const int PhysicalDamage = 29;
	public const int Visible = 30;
	public const int GameDestroyedListener = 31;
	public const int HealthListener = 32;
	public const int MoveDirectionListener = 33;
	public const int PerformingAttackListener = 34;
	public const int PlayerCoinsListener = 35;
	public const int PositionListener = 36;
	public const int RotationListener = 37;
	public const int VisibleListener = 38;
	public const int VisibleRemovedListener = 39;

	public const int TotalComponents = 40;

	public static readonly string[] ComponentNames =
	{
		"CameraModeListener",
		"Destroyed",
		"Uid",
		"Camera",
		"CameraMode",
		"CameraMove",
		"VirtualCamera",
		"CanMove",
		"AttackTargets",
		"EquippedWeapon",
		"PerformingAttack",
		"Weapon",
		"Dead",
		"Enemy",
		"HoveredObject",
		"Income",
		"IncomeTimer",
		"Instantiate",
		"MoveDirection",
		"Owner",
		"PlayerCoins",
		"Player",
		"Position",
		"Prefab",
		"Rotation",
		"Time",
		"Transform",
		"Health",
		"MagicDamage",
		"PhysicalDamage",
		"Visible",
		"GameDestroyedListener",
		"HealthListener",
		"MoveDirectionListener",
		"PerformingAttackListener",
		"PlayerCoinsListener",
		"PositionListener",
		"RotationListener",
		"VisibleListener",
		"VisibleRemovedListener"
	};

	public static readonly System.Type[] ComponentTypes =
	{
		typeof(CameraModeListenerComponent),
		typeof(Ecs.Common.Components.DestroyedComponent),
		typeof(Ecs.Common.Components.UidComponent),
		typeof(Ecs.Game.Components.Camera.CameraComponent),
		typeof(Ecs.Game.Components.Camera.CameraModeComponent),
		typeof(Ecs.Game.Components.Camera.CameraMoveComponent),
		typeof(Ecs.Game.Components.Camera.VirtualCameraComponent),
		typeof(Ecs.Game.Components.CanMoveComponent),
		typeof(Ecs.Game.Components.Combat.AttackTargetsComponent),
		typeof(Ecs.Game.Components.Combat.EquippedWeaponComponent),
		typeof(Ecs.Game.Components.Combat.PerformingAttackComponent),
		typeof(Ecs.Game.Components.Combat.WeaponComponent),
		typeof(Ecs.Game.Components.DeadComponent),
		typeof(Ecs.Game.Components.EnemyComponent),
		typeof(Ecs.Game.Components.HoveredObjectComponent),
		typeof(Ecs.Game.Components.IncomeComponent),
		typeof(Ecs.Game.Components.IncomeTimer),
		typeof(Ecs.Game.Components.InstantiateComponent),
		typeof(Ecs.Game.Components.MoveDirectionComponent),
		typeof(Ecs.Game.Components.OwnerComponent),
		typeof(Ecs.Game.Components.PlayerCoinsComponent),
		typeof(Ecs.Game.Components.PlayerComponent),
		typeof(Ecs.Game.Components.PositionComponent),
		typeof(Ecs.Game.Components.PrefabComponent),
		typeof(Ecs.Game.Components.RotationComponent),
		typeof(Ecs.Game.Components.TimeComponent),
		typeof(Ecs.Game.Components.TransformComponent),
		typeof(Ecs.Game.Components.UnitParameters.HealthComponent),
		typeof(Ecs.Game.Components.UnitParameters.MagicDamageComponent),
		typeof(Ecs.Game.Components.UnitParameters.PhysicalDamageComponent),
		typeof(Ecs.Game.Components.VisibleComponent),
		typeof(GameDestroyedListenerComponent),
		typeof(HealthListenerComponent),
		typeof(MoveDirectionListenerComponent),
		typeof(PerformingAttackListenerComponent),
		typeof(PlayerCoinsListenerComponent),
		typeof(PositionListenerComponent),
		typeof(RotationListenerComponent),
		typeof(VisibleListenerComponent),
		typeof(VisibleRemovedListenerComponent)
	};

	public static readonly Dictionary<Type, int> ComponentTypeToIndex = new Dictionary<Type, int>
	{
		{ typeof(CameraModeListenerComponent), 0 },
		{ typeof(Ecs.Common.Components.DestroyedComponent), 1 },
		{ typeof(Ecs.Common.Components.UidComponent), 2 },
		{ typeof(Ecs.Game.Components.Camera.CameraComponent), 3 },
		{ typeof(Ecs.Game.Components.Camera.CameraModeComponent), 4 },
		{ typeof(Ecs.Game.Components.Camera.CameraMoveComponent), 5 },
		{ typeof(Ecs.Game.Components.Camera.VirtualCameraComponent), 6 },
		{ typeof(Ecs.Game.Components.CanMoveComponent), 7 },
		{ typeof(Ecs.Game.Components.Combat.AttackTargetsComponent), 8 },
		{ typeof(Ecs.Game.Components.Combat.EquippedWeaponComponent), 9 },
		{ typeof(Ecs.Game.Components.Combat.PerformingAttackComponent), 10 },
		{ typeof(Ecs.Game.Components.Combat.WeaponComponent), 11 },
		{ typeof(Ecs.Game.Components.DeadComponent), 12 },
		{ typeof(Ecs.Game.Components.EnemyComponent), 13 },
		{ typeof(Ecs.Game.Components.HoveredObjectComponent), 14 },
		{ typeof(Ecs.Game.Components.IncomeComponent), 15 },
		{ typeof(Ecs.Game.Components.IncomeTimer), 16 },
		{ typeof(Ecs.Game.Components.InstantiateComponent), 17 },
		{ typeof(Ecs.Game.Components.MoveDirectionComponent), 18 },
		{ typeof(Ecs.Game.Components.OwnerComponent), 19 },
		{ typeof(Ecs.Game.Components.PlayerCoinsComponent), 20 },
		{ typeof(Ecs.Game.Components.PlayerComponent), 21 },
		{ typeof(Ecs.Game.Components.PositionComponent), 22 },
		{ typeof(Ecs.Game.Components.PrefabComponent), 23 },
		{ typeof(Ecs.Game.Components.RotationComponent), 24 },
		{ typeof(Ecs.Game.Components.TimeComponent), 25 },
		{ typeof(Ecs.Game.Components.TransformComponent), 26 },
		{ typeof(Ecs.Game.Components.UnitParameters.HealthComponent), 27 },
		{ typeof(Ecs.Game.Components.UnitParameters.MagicDamageComponent), 28 },
		{ typeof(Ecs.Game.Components.UnitParameters.PhysicalDamageComponent), 29 },
		{ typeof(Ecs.Game.Components.VisibleComponent), 30 },
		{ typeof(GameDestroyedListenerComponent), 31 },
		{ typeof(HealthListenerComponent), 32 },
		{ typeof(MoveDirectionListenerComponent), 33 },
		{ typeof(PerformingAttackListenerComponent), 34 },
		{ typeof(PlayerCoinsListenerComponent), 35 },
		{ typeof(PositionListenerComponent), 36 },
		{ typeof(RotationListenerComponent), 37 },
		{ typeof(VisibleListenerComponent), 38 },
		{ typeof(VisibleRemovedListenerComponent), 39 }
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
