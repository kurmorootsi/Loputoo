using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseAnswer : MonoBehaviour
{
	[SerializeField]
	public int rightAnswer;

	[SerializeField]
	public LevelManagerObject LevelManagerObject;

	public void chooseAnswer()
	{
		if (rightAnswer == 1)
		{
			StartCoroutine(CompleteLevel());

		} else
		{
			Debug.Log("Wrong answer, try again!");
		}
	}

	IEnumerator CompleteLevel()
	{
		yield return new WaitForSeconds(3.0f);
		LevelManagerObject.finishLevel();
	}

}
