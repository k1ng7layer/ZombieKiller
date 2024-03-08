//
//  SceneLoader.cs
//
//  Author:
//       Frederic Moreau <info@unitycoach.ca>
//
//  Copyright (c) 2018 Frederic Moreau, UnityCoach (Jikkou Publishing Inc.)

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	public void Load (string scene)
	{
		SceneManager.LoadScene (scene);
	}

	public void Load (int scene)
	{
		SceneManager.LoadScene (scene);
	}
}
