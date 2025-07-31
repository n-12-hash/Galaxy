using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage2 : MonoBehaviour
{
	[SerializeField] private AudioClip SE;
	public AudioSource audioSource;
	public Image fadePanel;             // フェード用のUIパネル（Image）
	public float fadeDuration;   // フェードの完了にかかる時間

	// フェード中かどうかを判定するフラグ
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
		isFading = true;  // フェード開始

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

		isFading = false; // ここは実際にはシーン切り替えなので意味はないですが、念のため

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
