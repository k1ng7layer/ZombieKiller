//
//  DigitalDisplay.cs
//
//  Author:
//       Frederic Moreau <info@unitycoach.ca>
//
//  Copyright (c) 2018 Frederic Moreau, UnityCoach (Jikkou Publishing Inc.)

using UnityCoach.GamePadNavigation;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Keypad demo, Digital display.
/// Links to a Selection Group.
/// </summary>
public class DigitalDisplay : MonoBehaviour
{
	public SelectionGroup subSelector;

	private Text _text;

	private void Awake ()
	{
		_text = GetComponentInChildren<Text>();
	}

	private void Start ()
	{
		if (subSelector == null)
		{
			Debug.LogError ("Unassigned Sub Selector");
			enabled = false;
			return;
		}

		// SubSelector.SelectionSubmitted is raised when a sub-selection element is submitted
		subSelector.SelectionSubmitted += SubSelector_SelectionSubmitted;
	}

	private void OnDestroy ()
	{
		subSelector.SelectionSubmitted -= SubSelector_SelectionSubmitted;
	}

	void SubSelector_SelectionSubmitted (int selection)
	{
		if (selection >= 0 && selection <= 9)
		{
			_text.text += selection.ToString ();
		}
		else if (selection == 10) // enter
		{
			// use value
		}
		else if (selection == 11) // clear
		{
			_text.text = string.Empty;
		}
		else if (selection == 12) // cancel
		{
			// nothing
		}
	}
}