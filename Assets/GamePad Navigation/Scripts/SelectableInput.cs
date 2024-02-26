﻿//
//  SelectableInput.cs
//
//  Author:
//       Frederic Moreau <info@unitycoach.ca>
//
//  Copyright (c) 2018 Frederic Moreau, UnityCoach (Jikkou Publishing Inc.)

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityCoach.GamePadNavigation
{
	[HelpURL ("http://unitycoach.ca/gamepad_navigation")]
	[RequireComponent (typeof (Selectable))]
	[AddComponentMenu ("UI/GamePad Navigation/Selectable Input")]
	/// <summary>
	/// Selectable Input.
	/// Executes Selectable Submit Event when a Button is pressed.
	/// </summary>
	public class SelectableInput : UIBehaviour
	{
		[Tooltip ("The Keycode associated with this Selectable.")]
		[SerializeField] string input;

		public enum Mode {SelectAndSubmit, SelectOnly, SubmitOnly};
		[SerializeField] Mode mode;

		private Selectable _selectable;

		protected override void Awake ()
		{
			_selectable = GetComponent<Selectable>();
		}
		
		private void Update ()
		{
			if (Input.GetButtonDown(input) && _selectable.interactable)
			{
				if (mode == Mode.SelectAndSubmit || mode == Mode.SelectOnly)
					_selectable.Select ();

				if (mode == Mode.SelectAndSubmit || mode == Mode.SubmitOnly)
				{
					BaseEventData data = new BaseEventData (EventSystem.current);
					ExecuteEvents.Execute (gameObject, data, ExecuteEvents.submitHandler);
				}
			}
		}
	}
}