using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerObject : MonoBehaviour
{
	[SerializeField]
	public int levelScene;

	[SerializeField]
	public GameObject levelCanvas;

	[SerializeField]
	public GameObject[] lvlButtons;

	public int givenStars;

	public int tries = 0;

	public void finishLevel()
	{
		Debug.Log("Correct answer! Level finished");

		PlayerPrefs.SetInt("level_" + levelScene, givenStars);

		for (int i = 0; i <= givenStars - 1; i++)
		{
			lvlButtons[i].SetActive(true);
		}

		levelCanvas.SetActive(true);
	}

	public void finishGame()
	{
		if (tries > 1)
		{
			StartCoroutine(CompleteLevel());
		}
	}

	IEnumerator CompleteLevel()
	{
		yield return new WaitForSeconds(3.0f);
		finishLevel();
	}
}
