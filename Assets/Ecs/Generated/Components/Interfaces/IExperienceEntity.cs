//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.3.2.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IExperienceEntity
{
	Ecs.Game.Components.ExperienceComponent Experience { get; }
	bool HasExperience { get; }

	void AddExperience(float newValue);
	void ReplaceExperience(float newValue);
	void RemoveExperience();
}