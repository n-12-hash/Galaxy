using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage2 : MonoBehaviour
{
	[SerializeField] private AudioClip SE;
	public AudioSource audioSource;
	public Image fadePanel;             // �t�F�[�h�p��UI�p�l���iImage�j
	public float fadeDuration;   // �t�F�[�h�̊����ɂ����鎞��

	// �t�F�[�h�����ǂ����𔻒肷��t���O
	public bool isFading { get; private set; } = false;

	public void FadeAndLoadScene()
	{
		fadePanel.enabled = true;
		StartCoroutine(FadeOutAndLoadScene());
		PlaySE(SE);
	}

	private void Start()
	{
		fadePanel.enabled = false;
		Color c = fadePanel.color;
		c.a = 0f;
		fadePanel.color = c;
	}

	public IEnumerator FadeOutAndLoadScene()
	{
		isFading = true;  // �t�F�[�h�J�n

		fadePanel.enabled = true;

		float elapsedTime = 0f;
		Color startColor = new Color(0, 0, 0, 0);
		Color endColor = new Color(0, 0, 0, 1);

		while (elapsedTime < fadeDuration)
		{
			elapsedTime += Time.deltaTime;
			float t = Mathf.Clamp01(elapsedTime / fadeDuration);
			fadePanel.color = Color.Lerp(startColor, endColor, t);
			yield return null;
		}

		fadePanel.color = endColor;

		isFading = false; // �����͎��ۂɂ̓V�[���؂�ւ��Ȃ̂ňӖ��͂Ȃ��ł����A�O�̂���

		SceneManager.LoadScene("Stage2");
	}

	private void PlaySE(AudioClip clip)
	{
		if (audioSource != null && clip != null)
		{
			audioSource.PlayOneShot(clip);
		}
	}
}
