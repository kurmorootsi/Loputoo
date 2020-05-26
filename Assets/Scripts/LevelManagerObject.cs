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

	public int tries = 0;

	public void finishLevel(int givenStars)
	{
		Debug.Log("Correct answer! Level finished");

		PlayerPrefs.SetInt("level_" + levelScene, givenStars);

		for (int i = 0; i <= givenStars - 1; i++)
		{
			lvlButtons[i].SetActive(true);
		}

		levelCanvas.SetActive(true);
	}

}
