//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IWeaponRootEntity
{
	Ecs.Game.Components.WeaponRootComponent WeaponRoot { get; }
	bool HasWeaponRoot { get; }

	void AddWeaponRoot(UnityEngine.Transform newValue);
	void ReplaceWeaponRoot(UnityEngine.Transform newValue);
	void RemoveWeaponRoot();
}
