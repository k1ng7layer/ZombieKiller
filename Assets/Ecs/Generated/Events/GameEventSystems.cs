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

public sealed class GameEventSystems : Feature
{
	public GameEventSystems(IContext<GameEntity> context)
	{
		Add(new GameActiveEventSystem(context)); // priority: 0
		Add(new GameActiveRemovedEventSystem(context)); // priority: 0
		Add(new ActiveAbilityEventSystem(context)); // priority: 0
		Add(new ActiveAbilityRemovedEventSystem(context)); // priority: 0
		Add(new BehaviourTreeEventSystem(context)); // priority: 0
		Add(new CameraModeEventSystem(context)); // priority: 0
		Add(new DeadEventSystem(context)); // priority: 0
		Add(new DestinationEventSystem(context)); // priority: 0
		Add(new GameDestroyedEventSystem(context)); // priority: 0
		Add(new EquippedWeaponEventSystem(context)); // priority: 0
		Add(new ExperienceEventSystem(context)); // priority: 0
		Add(new HealthEventSystem(context)); // priority: 0
		Add(new HitCounterEventSystem(context)); // priority: 0
		Add(new LinkRemovedEventSystem(context)); // priority: 0
		Add(new MaxHealthEventSystem(context)); // priority: 0
		Add(new MoveDirectionEventSystem(context)); // priority: 0
		Add(new MoveDirectionRemovedEventSystem(context)); // priority: 0
		Add(new MovingEventSystem(context)); // priority: 0
		Add(new MovingRemovedEventSystem(context)); // priority: 0
		Add(new ParentTransformEventSystem(context)); // priority: 0
		Add(new PerformingAttackEventSystem(context)); // priority: 0
		Add(new PerformingAttackRemovedEventSystem(context)); // priority: 0
		Add(new PlayerCoinsEventSystem(context)); // priority: 0
		Add(new PositionEventSystem(context)); // priority: 0
		Add(new RotationEventSystem(context)); // priority: 0
		Add(new GameTimerEventSystem(context)); // priority: 0
		Add(new UnitLevelEventSystem(context)); // priority: 0
		Add(new VisibleEventSystem(context)); // priority: 0
		Add(new VisibleRemovedEventSystem(context)); // priority: 0
	}
}
