using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour
{
	public int nextSceneLoad;
	public int currentScene;

    
    void Start()
    {
		currentScene = SceneManager.GetActiveScene().buildIndex;

		nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
	}

	public void loadNextLevel()
	{
		SceneManager.LoadScene(nextSceneLoad);

		if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
		{
			PlayerPrefs.SetInt("levelAt", nextSceneLoad);
		}
	}

}
