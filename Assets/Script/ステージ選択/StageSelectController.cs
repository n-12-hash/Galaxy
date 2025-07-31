using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectController : MonoBehaviour
{
	public Button hiddenStageButton;

	private void Start()
	{
		hiddenStageButton.gameObject.SetActive(false);

		// 全てのステージがアンロック済みか判定
		bool unlockedAll = true;
		foreach (var key in new string[] { "Stage1", "Stage2", "Stage3" })
		{
			if (PlayerPrefs.GetInt($"Unlocked_{key}", 0) != 1)
			{
				unlockedAll = false;
				break;
			}
		}

		if (unlockedAll)
		{
			hiddenStageButton.gameObject.SetActive(true);
			hiddenStageButton.onClick.AddListener(() =>
			{
				SceneManager.LoadScene("BossStage");
			});
		}
	}
}
