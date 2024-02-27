//
//  LevelSelector.cs
//
//  Author:
//       Frederic Moreau <info@unitycoach.ca>
//
//  Copyright (c) 2018 Frederic Moreau, UnityCoach (Jikkou Publishing Inc.)

using System.Collections.Generic;
using UnityCoach.GamePadNavigation;
using UnityCoach.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class Level
{
//	public Sprite background;
	public string title;
	public string scene;
	[TextArea (3, 10)]
	public string description;
	public Gradient backgroundGradient = new Gradient ();
}

/// <summary>
/// Level selector demo.
/// </summary>
public class LevelSelector : MonoBehaviour
{
	public List<Level> levels;
	public Button levelButtonReference;
	public SelectionScrollView levelView;
	public ScrollingListView yesNo;

//	public SpriteRenderer background;
	public GradientImage gradientBackground;
	public Text descriptionText;

	private void Start ()
	{
		foreach (Level level in levels)
			AddLevelButton (level);

		// SelectionScrollView.Init () must be called after populating the view content
		levelView.Init ();

		levelView.Content.GetComponentInChildren<Selectable>().Select();

		levelView.SelectionChanged += SelectionChanged;
		levelView.SelectionSubmitted += SelectionSubmitted;

		levelView.Scrolled += LevelView_Scrolled;

		yesNo.SelectionSubmitted += YesNo_SelectionSubmitted;
		yesNo.SelectionCancelled += YesNo_SelectionCancelled;
	}

	private void OnDestroy ()
	{
		levelView.SelectionChanged -= SelectionChanged;
		levelView.SelectionSubmitted -= SelectionSubmitted;

		levelView.Scrolled -= LevelView_Scrolled;

		yesNo.SelectionSubmitted -= YesNo_SelectionSubmitted;
		yesNo.SelectionCancelled -= YesNo_SelectionCancelled;
	}

	void LevelView_Scrolled (Vector2 position)
	{
		yesNo.transform.position = yesNo.transform.position = levelView.Selectables[levelView.Selection].transform.position;
	}

	void YesNo_SelectionCancelled (int selection)
	{
		Debug.Log ("Cancelled");
		yesNo.gameObject.SetActive(false);

		levelView.Selectables[levelView.Selection].GetComponent<Selectable>().Select();
	}

	void YesNo_SelectionSubmitted (int selection)
	{
		Debug.Log (selection == 0 ? "Loading : " + levels[levelView.Selection].title: "Cancelled");
		Debug.Log (selection == 0 ? "Loading : " + levels[levelView.Selection].scene: "Cancelled");

		string sceneName = levels[levelView.Selection].scene;
		if (selection == 0 && sceneName != string.Empty)
		{
			SceneManager.LoadScene (sceneName);
		}
		else
		{
			yesNo.gameObject.SetActive(false);
			levelView.Selectables[levelView.Selection].GetComponent<Selectable>().Select();
		}
	}

	void SelectionSubmitted (int selection)
	{
		yesNo.transform.position = levelView.Selectables[selection].transform.position;
		yesNo.gameObject.SetActive(true);
		yesNo.Select ();
		yesNo.Selection = 0;
	}

	public void SelectionChanged (int selection)
	{
		PreviewLevel (levels[selection]);
	}

	private void AddLevelButton (Level level)
	{
		GameObject buttonObject = (GameObject) Instantiate (levelButtonReference.gameObject, levelView.Content);
		buttonObject.GetComponentInChildren<Text>().text = level.title;
	}

	private void PreviewLevel (Level level)
	{
//		background.sprite = level.background;
		gradientBackground.gradient = level.backgroundGradient;
		descriptionText.text = level.description;
	}
}