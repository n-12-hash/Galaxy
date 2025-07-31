using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
	[SerializeField] private Button startButton;
	[SerializeField] private Button leftArrowButton;
	[SerializeField] private Button resetButton;

	private bool isProcessing = false;

	private void Start()
	{
		// �X�^�[�g�{�^���̃N���b�N�C�x���g�ɓo�^
		startButton.onClick.AddListener(OnStartButtonClicked);
	}

	private void OnStartButtonClicked()
	{
		if (isProcessing) return;  // �A�Ŗh�~

		isProcessing = true;

		// ���̃{�^���𖳌���
		startButton.interactable = false; ;
		leftArrowButton.interactable = false;
		resetButton.interactable = false;

		// �����ɃX�^�[�g�����i�t�F�[�h�J�n��V�[���J�ڂȂǁj������
		Debug.Log("�X�^�[�g��������܂���");

		// ��: �t�F�[�h�����J�n�Ȃ�
	}
}

