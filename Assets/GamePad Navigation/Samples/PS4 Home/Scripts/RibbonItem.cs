//
//  RibbonItem.cs
//
//  Author:
//       Frederic Moreau <info@unitycoach.ca>
//
//  Copyright (c) 2018 Frederic Moreau, UnityCoach (Jikkou Publishing Inc.)

using System.Collections.Generic;
using UnityEngine;

namespace PS4Home
{
	/// <summary>
	/// Ribbon Item.
	/// </summary>
	[CreateAssetMenu(menuName = "PS4/New RibbonItem", fileName = "New RibbonItem.asset")]
	public class RibbonItem : ScriptableObject
	{
		public enum Type {Simple, SubCategory};

//		new public string name;
		[Multiline] public string description;
		public Texture thumbnail;
		public Gradient gradient;
		public Type type;
		public string sceneName;

		public List<RibbonSubItem> subItems;
	}
}