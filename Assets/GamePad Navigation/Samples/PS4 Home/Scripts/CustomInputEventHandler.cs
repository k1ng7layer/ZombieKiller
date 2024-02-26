//
//  CustomInputEventHandler.cs
//
//  Author:
//       Frederic Moreau <info@unitycoach.ca>
//
//  Copyright (c) 2018 Frederic Moreau, UnityCoach (Jikkou Publishing Inc.)

using UnityCoach.GamePadNavigation;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PS4Home
{
	/// <summary>
	/// Custom Input Event Handler.
	/// Demo of ICustomKeycodeHandler and ICustomInputHandler interfaces.
	/// Catches button press on Ribbon items.
	/// </summary>
	public class CustomInputEventHandler : UIBehaviour, ICustomKeycodeHandler, ICustomInputHandler
	{
		public bool IsHandlingKeycode (KeyCode keycode)
		{
			return (keycode == KeyCode.JoystickButton8 || 
				keycode == KeyCode.JoystickButton9 || 
				keycode == KeyCode.Z
			);
		}

		public void OnCustomKeycode (KeyCode keycode)
		{
			switch (keycode)
			{
				case KeyCode.JoystickButton8:
					Debug.Log("Share pressed on " + gameObject.name, gameObject);
					break;

				case KeyCode.JoystickButton9:
					Debug.Log("Options pressed on " + gameObject.name, gameObject);
					break;

				case KeyCode.Z:
					Debug.Log("Z pressed on " + gameObject.name, gameObject);
					break;
			}
		}

		public bool IsHandlingInput (string input)
		{
			return (input == "options" ||
				input == "share"
			);
		}

		public void OnCustomInput (string input)
		{
			switch (input)
			{
				case "share":
					Debug.Log("Share pressed on " + gameObject.name, gameObject);
					break;

				case "options":
					Debug.Log("Options pressed on " + gameObject.name, gameObject);
					break;
			}
		}
	}
}