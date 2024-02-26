//
//  MenuItem.cs
//
//  Author:
//       Frederic Moreau <info@unitycoach.ca>
//
//  Copyright (c) 2018 Frederic Moreau, UnityCoach (Jikkou Publishing Inc.)

using UnityEngine;

namespace PS4Home
{
	/// <summary>
	/// PS4 Demo Menu Item.
	/// </summary>
	[CreateAssetMenu(menuName = "PS4/New MenuItem", fileName = "New MenuItem.asset")]
	public class MenuItem : ScriptableObject
	{
		public Sprite icon;
		public string text;
		public string title;
		[Multiline] public string description;

		public bool hideByDefault;
	}
}