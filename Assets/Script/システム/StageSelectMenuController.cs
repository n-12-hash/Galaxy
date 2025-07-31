using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StageSelectMenuController : MonoBehaviour
{

	[SerializeField] private Button stage1;
	[SerializeField] private Button stage2;
	[SerializeField] private Button stage3;
	[SerializeField] private Button stage4;
	[SerializeField] private Button stage5;

	private bool isProcessing = false;

	private void Start()
	{
		// �X�^�[�g�{�^���̃N���b�N�C�x���g�ɓo�^
		stage1.onClick.AddListener(OnStartButtonClicked);
		stage2.onClick.AddListener(OnStartButtonClicked);
		stage3.onClick.AddListener(OnStartButtonClicked);
		stage4.onClick.AddListener(OnStartButtonClicked);
		stage5.onClick.AddListener(OnStartButtonClicked);
	}

	private void OnStartButtonClicked()
	{
		if (isProcessing) return;  // �A�Ŗh�~

		isProcessing = true;

		// ���̃{�^���𖳌���
		stage1.interactable = false; 
		stage2.interactable = false; 
		stage3.interactable = false; 
		stage4.interactable = false; 
		stage5.interactable = false; 


		// �����ɃX�^�[�g�����i�t�F�[�h�J�n��V�[���J�ڂȂǁj������
		Debug.Log("�X�^�[�g��������܂���");

		// ��: �t�F�[�h�����J�n�Ȃ�
	}
}

