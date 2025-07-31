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


	public void OnResetClicked()
	{
		PlaySE(SE);

		PlayerPrefs.DeleteAll();  // 全データをリセット
		PlayerPrefs.Save();

		Debug.Log("PlayerPrefs: 全データをリセットしました");

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
