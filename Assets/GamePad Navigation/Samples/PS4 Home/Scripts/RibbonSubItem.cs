//
//  RibbonSubItem.cs
//
//  Author:
//       Frederic Moreau <info@unitycoach.ca>
//
//  Copyright (c) 2018 Frederic Moreau, UnityCoach (Jikkou Publishing Inc.)

using UnityEngine;

namespace PS4Home
{
	/// <summary>
	/// Ribbon sub item.
	/// Currently not used.
	/// </summary>
	[CreateAssetMenu(menuName = "PS4/New RibbonSubItem", fileName = "New RibbonSubItem.asset")]
	public class RibbonSubItem : ScriptableObject
	{
		public Texture thumbnail;
		public System.Action action;
	}
}