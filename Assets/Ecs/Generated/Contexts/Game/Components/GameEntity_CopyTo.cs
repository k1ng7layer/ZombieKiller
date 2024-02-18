//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using JCMG.EntitasRedux;

public partial class GameEntity
{
	/// <summary>
	/// Copies <paramref name="component"/> to this entity as a new component instance.
	/// </summary>
	public void CopyComponentTo(IComponent component)
	{
		#if !ENTITAS_REDUX_NO_IMPL
		if (component is Ecs.Common.Components.UidComponent Uid)
		{
			CopyUidTo(Uid);
		}
		else if (component is Ecs.Common.Components.DestroyedComponent Destroyed)
		{
			IsDestroyed = true;
		}
		else if (component is Ecs.Game.Components.UnitLevelComponent UnitLevel)
		{
			CopyUnitLevelTo(UnitLevel);
		}
		else if (component is Ecs.Game.Components.ExperienceComponent Experience)
		{
			CopyExperienceTo(Experience);
		}
		else if (component is Ecs.Game.Components.PortalComponent Portal)
		{
			CopyPortalTo(Portal);
		}
		else if (component is Ecs.Game.Components.InstantiateComponent Instantiate)
		{
			IsInstantiate = true;
		}
		else if (component is Ecs.Game.Components.PositionComponent Position)
		{
			CopyPositionTo(Position);
		}
		else if (component is Ecs.Game.Components.PlayerCoinsComponent PlayerCoins)
		{
			CopyPlayerCoinsTo(PlayerCoins);
		}
		else if (component is Ecs.Game.Components.WeaponRootComponent WeaponRoot)
		{
			CopyWeaponRootTo(WeaponRoot);
		}
		else if (component is Ecs.Game.Components.DeadComponent Dead)
		{
			IsDead = true;
		}
		else if (component is Ecs.Game.Components.TimeComponent Time)
		{
			CopyTimeTo(Time);
		}
		else if (component is Ecs.Game.Components.IncomeTimer IncomeTimer)
		{
			CopyIncomeTimerTo(IncomeTimer);
		}
		else if (component is Ecs.Game.Components.ParentTransformComponent ParentTransform)
		{
			CopyParentTransformTo(ParentTransform);
		}
		else if (component is Ecs.Game.Components.PrefabComponent Prefab)
		{
			CopyPrefabTo(Prefab);
		}
		else if (component is Ecs.Game.Components.CanMoveComponent CanMove)
		{
			IsCanMove = true;
		}
		else if (component is Ecs.Game.Components.ActiveComponent Active)
		{
			IsActive = true;
		}
		else if (component is Ecs.Game.Components.SpeedComponent Speed)
		{
			CopySpeedTo(Speed);
		}
		else if (component is Ecs.Game.Components.RotationComponent Rotation)
		{
			CopyRotationTo(Rotation);
		}
		else if (component is Ecs.Game.Components.TransformComponent Transform)
		{
			CopyTransformTo(Transform);
		}
		else if (component is Ecs.Game.Components.LinkComponent Link)
		{
			CopyLinkTo(Link);
		}
		else if (component is Ecs.Game.Components.MoveDirectionComponent MoveDirection)
		{
			CopyMoveDirectionTo(MoveDirection);
		}
		else if (component is Ecs.Game.Components.EnemyComponent Enemy)
		{
			CopyEnemyTo(Enemy);
		}
		else if (component is Ecs.Game.Components.ProjectileComponent Projectile)
		{
			CopyProjectileTo(Projectile);
		}
		else if (component is Ecs.Game.Components.VisibleComponent Visible)
		{
			IsVisible = true;
		}
		else if (component is Ecs.Game.Components.PlayerComponent Player)
		{
			IsPlayer = true;
		}
		else if (component is Ecs.Game.Components.HoveredObjectComponent HoveredObject)
		{
			CopyHoveredObjectTo(HoveredObject);
		}
		else if (component is Ecs.Game.Components.OwnerComponent Owner)
		{
			CopyOwnerTo(Owner);
		}
		else if (component is Ecs.Game.Components.IncomeComponent Income)
		{
			CopyIncomeTo(Income);
		}
		else if (component is Ecs.Game.Components.MaxHealthComponent MaxHealth)
		{
			CopyMaxHealthTo(MaxHealth);
		}
		else if (component is Ecs.Game.Components.Camera.CameraModeComponent CameraMode)
		{
			CopyCameraModeTo(CameraMode);
		}
		else if (component is Ecs.Game.Components.Camera.CameraMoveComponent CameraMove)
		{
			IsCameraMove = true;
		}
		else if (component is Ecs.Game.Components.Camera.VirtualCameraComponent VirtualCamera)
		{
			IsVirtualCamera = true;
		}
		else if (component is Ecs.Game.Components.Camera.CameraComponent Camera)
		{
			IsCamera = true;
		}
		else if (component is Ecs.Game.Components.UnitParameters.PhysicalDamageComponent PhysicalDamage)
		{
			CopyPhysicalDamageTo(PhysicalDamage);
		}
		else if (component is Ecs.Game.Components.UnitParameters.HealthComponent Health)
		{
			CopyHealthTo(Health);
		}
		else if (component is Ecs.Game.Components.UnitParameters.MagicDamageComponent MagicDamage)
		{
			CopyMagicDamageTo(MagicDamage);
		}
		else if (component is Ecs.Game.Components.Combat.WeaponComponent Weapon)
		{
			CopyWeaponTo(Weapon);
		}
		else if (component is Ecs.Game.Components.Combat.PerformingAttackComponent PerformingAttack)
		{
			IsPerformingAttack = true;
		}
		else if (component is Ecs.Game.Components.Combat.EquippedWeaponComponent EquippedWeapon)
		{
			CopyEquippedWeaponTo(EquippedWeapon);
		}
		else if (component is Ecs.Game.Components.Combat.AttackTargetsComponent AttackTargets)
		{
			CopyAttackTargetsTo(AttackTargets);
		}

		#endif
	}

	/// <summary>
	/// Copies all components on this entity to <paramref name="copyToEntity"/>.
	/// </summary>
	public void CopyTo(GameEntity copyToEntity)
	{
		for (var i = 0; i < GameComponentsLookup.TotalComponents; ++i)
		{
			if (HasComponent(i))
			{
				if (copyToEntity.HasComponent(i))
				{
					throw new EntityAlreadyHasComponentException(
						i,
						"Cannot copy component '" +
						GameComponentsLookup.ComponentNames[i] +
						"' to " +
						this +
						"!",
						"If replacement is intended, please call CopyTo() with `replaceExisting` set to true.");
				}

				var component = GetComponent(i);
				copyToEntity.CopyComponentTo(component);
			}
		}
	}

	/// <summary>
	/// Copies all components on this entity to <paramref name="copyToEntity"/>; if <paramref name="replaceExisting"/>
	/// is true any of the components that <paramref name="copyToEntity"/> has that this entity has will be replaced,
	/// otherwise they will be skipped.
	/// </summary>
	public void CopyTo(GameEntity copyToEntity, bool replaceExisting)
	{
		for (var i = 0; i < GameComponentsLookup.TotalComponents; ++i)
		{
			if (!HasComponent(i))
			{
				continue;
			}

			if (!copyToEntity.HasComponent(i) || replaceExisting)
			{
				var component = GetComponent(i);
				copyToEntity.CopyComponentTo(component);
			}
		}
	}

	/// <summary>
	/// Copies components on this entity at <paramref name="indices"/> in the <see cref="GameComponentsLookup"/> to
	/// <paramref name="copyToEntity"/>. If <paramref name="replaceExisting"/> is true any of the components that
	/// <paramref name="copyToEntity"/> has that this entity has will be replaced, otherwise they will be skipped.
	/// </summary>
	public void CopyTo(GameEntity copyToEntity, bool replaceExisting, params int[] indices)
	{
		for (var i = 0; i < indices.Length; ++i)
		{
			var index = indices[i];

			// Validate that the index is within range of the component lookup
			if (index < 0 && index >= GameComponentsLookup.TotalComponents)
			{
				const string OUT_OF_RANGE_WARNING =
					"Component Index [{0}] is out of range for [{1}].";

				const string HINT = "Please ensure any CopyTo indices are valid.";

				throw new IndexOutOfLookupRangeException(
					string.Format(OUT_OF_RANGE_WARNING, index, nameof(GameComponentsLookup)),
					HINT);
			}

			if (!HasComponent(index))
			{
				continue;
			}

			if (!copyToEntity.HasComponent(index) || replaceExisting)
			{
				var component = GetComponent(index);
				copyToEntity.CopyComponentTo(component);
			}
		}
	}
}
