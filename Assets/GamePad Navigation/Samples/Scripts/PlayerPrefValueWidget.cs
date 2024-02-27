//
//  PlayerPrefValueWidget.cs
//
//  Author:
//       Frederic Moreau <info@unitycoach.ca>
//
//  Copyright (c) 2018 Frederic Moreau, UnityCoach (Jikkou Publishing Inc.)

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Player preference value widget.
/// Displays an int or float value, and save it.
/// Can increase/decrease the value with a Vector2 method to be used with SelectableCustom.
/// </summary>
public class PlayerPrefValueWidget : MonoBehaviour
{
	public enum TYPE {Integer, Float};

	[SerializeField] string valueName;
	[SerializeField] TYPE type;

	[SerializeField] float _defaultF = 1f;
	[SerializeField] float minF = 0f;
	[SerializeField] float maxF = 10f;
	[SerializeField] float increment = 0.1f;

	[SerializeField] int _default = 1;
	[SerializeField] int min = 0;
	[SerializeField] int max = 10;

	[SerializeField] bool loop = true;


	Text text;

	int _intValue;
	public int intValue
	{
		get { return _intValue; }
		private set
		{
			if (_intValue != value)
			{
				if (value > max)
					_intValue = loop ? min : max;
				else if (value < min)
					_intValue = loop ? max : min;
				else
					_intValue = value;

				PlayerPrefs.SetInt (valueName, _intValue);
				text.text = _intValue.ToString();
			}
		}
	}

	float _floatValue;
	public float floatValue
	{
		get { return _floatValue; }
		private set
		{
			if (_floatValue != value)
			{
				if (value > maxF)
					_floatValue = loop ? minF : maxF;
				else if (value < minF)
					_floatValue = loop ? maxF : minF;
				else
					_floatValue = value;

				PlayerPrefs.SetFloat (valueName, _floatValue);
				text.text = _floatValue.ToString();
			}
		}
	}

	void Awake ()
	{
		text = GetComponentInChildren<Text>();

		if (type == TYPE.Integer)
		{
			_intValue = PlayerPrefs.GetInt (valueName, _default);
			text.text = intValue.ToString();
		}
		else
		{
			_floatValue = PlayerPrefs.GetFloat (valueName, _defaultF);
			text.text = floatValue.ToString();
		}

	}

	public void ChangeValue (Vector2 vector)
	{
		if (type == TYPE.Integer)
			intValue += Mathf.RoundToInt (vector.y);
		else
			floatValue += vector.y*increment;
	}
}