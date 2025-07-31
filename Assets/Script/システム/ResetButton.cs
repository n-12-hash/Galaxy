using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
	[SerializeField] private AudioClip SE;
	public AudioSource audioSource;
	public Button resetButton;
	public string sceneToReload = "StageSelect";  // ���Z�b�g��ɖ߂�V�[����

	void Start()
	{
		if (resetButton != null)
			resetButton.onClick.AddListener(OnResetClicked);
	}


	public void OnResetClicked()
	{
		PlaySE(SE);

		PlayerPrefs.DeleteAll();  // �S�f�[�^�����Z�b�g
		PlayerPrefs.Save();

		Debug.Log("PlayerPrefs: �S�f�[�^�����Z�b�g���܂���");

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
