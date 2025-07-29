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

	void OnResetClicked()
	{
		PlaySE(SE);
		// �S�X�e�[�W����f�[�^���폜
		PlayerPrefs.DeleteKey("MAX_UNLOCKED_STAGE");
		// �X�R�A�ۑ������Z�b�g�������Ȃ�
		PlayerPrefs.DeleteKey("SCORE");
		PlayerPrefs.Save();  // �O�̂��ߕۑ�
		Debug.Log("�Z�[�u�f�[�^�����Z�b�g���܂���");

		// �C�ӂ̃V�[���ֈړ�
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
