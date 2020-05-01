using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour
{
	public int nextSceneLoad;
	public int currentScene;

	[SerializeField]
	public int givenStars;
    
    void Start()
    {
		currentScene = SceneManager.GetActiveScene().buildIndex;

		nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
	}

	public void loadNextLevel()
	{
		PlayerPrefs.SetInt("level_"+currentScene, givenStars);

		Debug.Log("pref set-level_" + currentScene + " stars-" + givenStars);

		SceneManager.LoadScene(nextSceneLoad);

		if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
		{
			PlayerPrefs.SetInt("levelAt", nextSceneLoad);
		}
	}

}
