using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
	[SerializeField] private AudioClip SE;
	public AudioSource audioSource;
	public Button resetButton;
	public string sceneToReload = "StageSelect";  // リセット後に戻るシーン名

	void Start()
	{
		if (resetButton != null)
			resetButton.onClick.AddListener(OnResetClicked);
	}

	void OnResetClicked()
	{
		PlaySE(SE);
		// 全ステージ解放データを削除
		PlayerPrefs.DeleteKey("MAX_UNLOCKED_STAGE");
		// スコア保存もリセットしたいなら
		PlayerPrefs.DeleteKey("SCORE");
		PlayerPrefs.Save();  // 念のため保存
		Debug.Log("セーブデータをリセットしました");

		// 任意のシーンへ移動
		SceneManager.LoadScene(sceneToReload);
	}

	private void PlaySE(AudioClip clip)
	{
		if (audioSource != null && clip != null)
		{
			audioSource.PlayOneShot(clip);
		}
	}
}
