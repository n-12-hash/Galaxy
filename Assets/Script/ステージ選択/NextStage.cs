using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
	public void LoadNextStage()
	{
		int currentIndex = SceneManager.GetActiveScene().buildIndex;
		if (currentIndex + 1 < SceneManager.sceneCountInBuildSettings)
		{
			SceneManager.LoadScene(currentIndex + 1);
		}
		else
		{
			Debug.LogWarning("最後のシーンです：これ以上ステージがありません");
			SceneManager.LoadScene("StageSelect");
		}
	}
}