using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SceneController : MonoBehaviour
{
	[SerializeField] private AudioClip SE;
	public AudioSource audioSource;
	public Image fadePanel;             // �t�F�[�h�p��UI�p�l���iImage�j
	public float fadeDuration;   // �t�F�[�h�̊����ɂ����鎞��
	public static string sceneName;

	// �u���̃��\�b�h�����s���ꂽ���ɊJ���Ă���V�[���̖��O�v���擾����B
	// ����̏ꍇ�́A�Q�[���I�[�o�[�̏��������������ɁA���̃��\�b�h���Ăяo���B
	public static void CurrentSceneName()
	{
		sceneName = SceneManager.GetActiveScene().name;
		Debug.Log(sceneName);
	}



	// ��L�̃��\�b�h�Ŏ擾���ꂽ�V�[���ɖ߂�B
	// ����̏ꍇ�́A�R���e�B�j���[�{�^�������������ɂ��̃��\�b�h�����s����B
	public  void BackToBeforeScene()
	{
		StartCoroutine(FadeOutAndLoadScene());
		PlaySE(SE);
	}

	public IEnumerator FadeOutAndLoadScene()
	{
		fadePanel.enabled = true;                 // �p�l����L����
		float elapsedTime = 0.0f;                 // �o�ߎ��Ԃ�������
		Color startColor = fadePanel.color;       // �t�F�[�h�p�l���̊J�n�F���擾
		Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f); // �t�F�[�h�p�l���̍ŏI�F��ݒ�

		// �t�F�[�h�A�E�g�A�j���[�V���������s
		while (elapsedTime < fadeDuration)
		{
			elapsedTime += Time.deltaTime;                        // �o�ߎ��Ԃ𑝂₷
			float t = Mathf.Clamp01(elapsedTime / fadeDuration);  // �t�F�[�h�̐i�s�x���v�Z
			fadePanel.color = Color.Lerp(startColor, endColor, t); // �p�l���̐F��ύX���ăt�F�[�h�A�E�g
			yield return null;                                     // 1�t���[���ҋ@
		}

		fadePanel.color = endColor;  // �t�F�[�h������������ŏI�F�ɐݒ�
		SceneManager.LoadScene(sceneName);
	}

	private void PlaySE(AudioClip clip)
	{
		if (audioSource != null && clip != null)
		{
			audioSource.PlayOneShot(clip);
		}
	}

}