//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IWeaponEntity
{
	Ecs.Game.Components.Combat.WeaponComponent Weapon { get; }
	bool HasWeapon { get; }

	void AddWeapon(Game.Utils.EWeaponId newWeaponId);
	void ReplaceWeapon(Game.Utils.EWeaponId newWeaponId);
	void RemoveWeapon();
}
