using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
	public Button resetButton;
	public string sceneToReload = "StageSelect";  // リセット後に戻るシーン名

	void Start()
	{
		if (resetButton != null)
			resetButton.onClick.AddListener(OnResetClicked);
	}

	void OnResetClicked()
	{
		// 全ステージ解放データを削除
		PlayerPrefs.DeleteKey("MAX_UNLOCKED_STAGE");
		// スコア保存もリセットしたいなら
		PlayerPrefs.DeleteKey("SCORE");
		PlayerPrefs.Save();  // 念のため保存
		Debug.Log("セーブデータをリセットしました");

		// 任意のシーンへ移動
		SceneManager.LoadScene(sceneToReload);
	}
}
