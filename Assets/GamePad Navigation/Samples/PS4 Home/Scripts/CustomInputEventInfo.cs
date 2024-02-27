//
//  CustomInputEventInfo.cs
//
//  Author:
//       Frederic Moreau <info@unitycoach.ca>
//
//  Copyright (c) 2018 Frederic Moreau, UnityCoach (Jikkou Publishing Inc.)

using UnityCoach.GamePadNavigation;
using UnityEngine;
using UnityEngine.UI;

namespace PS4Home
{
	[RequireComponent (typeof (Text))]
	/// <summary>
	/// Displays inputs the current selection handles.
	/// </summary>
	public class CustomInputEventInfo : MonoBehaviour
	{
		Text _text;

		void Awake ()
		{
			_text = GetComponent<Text>();
			_text.text = string.Empty;
		}

		void Start ()
		{
			CustomInputEventManager.SelectionChanged += CustomInputEventManager_SelectionChanged;
		}

		void CustomInputEventManager_SelectionChanged (GameObject selection)
		{
			string text = "Custom Input Event Info :";

			foreach (KeyCode k in CustomInputEventManager.customKeycodes)
				if (CustomInputEventManager.customKeycodeHandler != null &&
					CustomInputEventManager.customKeycodeHandler.IsHandlingKeycode(k))
					text += string.Format("\n{0}", k);

			foreach (string i in CustomInputEventManager.customInputs)
				if (CustomInputEventManager.customInputHandler != null &&
					CustomInputEventManager.customInputHandler.IsHandlingInput(i))
					text += string.Format("\n{0}", i);

			_text.text = text;
		}
	}
}