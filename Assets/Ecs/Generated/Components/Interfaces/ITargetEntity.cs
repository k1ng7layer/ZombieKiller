//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface ITargetEntity
{
	Ecs.Game.Components.Ai.TargetComponent Target { get; }
	bool HasTarget { get; }

	void AddTarget(Ecs.Extensions.UidGenerator.Uid newTargetUid);
	void ReplaceTarget(Ecs.Extensions.UidGenerator.Uid newTargetUid);
	void RemoveTarget();
}
