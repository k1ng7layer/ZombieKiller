//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IMaxHealthEntity
{
	Ecs.Game.Components.UnitParameters.MaxHealthComponent MaxHealth { get; }
	bool HasMaxHealth { get; }

	void AddMaxHealth(float newValue);
	void ReplaceMaxHealth(float newValue);
	void RemoveMaxHealth();
}
