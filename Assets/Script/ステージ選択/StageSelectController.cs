using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectController : MonoBehaviour
{
	public Button hiddenStageButton;

	private void Start()
	{
		hiddenStageButton.gameObject.SetActive(false);

		bool unlockedAny = false;
		foreach (var key in new string[] { "Stage1", "Stage2", "Stage3" })
		{
			if (PlayerPrefs.GetInt($"Unlocked_{key}", 0) == 1)
			{
				unlockedAny = true;
				break;
			}
		}

		if (unlockedAny)
		{
			hiddenStageButton.gameObject.SetActive(true);
			hiddenStageButton.onClick.AddListener(() => SceneManager.LoadScene("BossStage"));
		}
	}
}


