using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
	[SerializeField]
	public int loadScene;

	public int givenStars;

	public GameObject[] lvlButtons;

	private void Start()
	{
		Debug.Log("started level-" + loadScene);

		givenStars = PlayerPrefs.GetInt("level_" + loadScene);

		Debug.Log("stars given-" + givenStars);

		if (givenStars < 1)
		{
			return;
		}
		for (int i = 0; i <= givenStars-1; i++)
		{
			lvlButtons[i].SetActive(true);
		}
	}

	public void loadLevelScene()
	{
		SceneManager.LoadScene(loadScene);
	}
}
