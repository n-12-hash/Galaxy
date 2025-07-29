using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
	[SerializeField] private AudioClip SE;
	public AudioSource audioSource;
	public Image fadePanel;             // フェード用のUIパネル（Image）
	public float fadeDuration;   // フェードの完了にかかる時間
	/*public void change_button()
	{

	}*/
	public void FadeAndLoadScene()
	{
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

	private void Update()
	{
		if (Mathf.Approximately(Time.timeScale, 0f))
		{
			return;
		}
	}

	public IEnumerator FadeOutAndLoadScene()
	{
		fadePanel.enabled = true;                 // パネルを有効化
		float elapsedTime = 0.0f;                 // 経過時間を初期化
		Color startColor = fadePanel.color;       // フェードパネルの開始色を取得
		Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f); // フェードパネルの最終色を設定

		// フェードアウトアニメーションを実行
		while (elapsedTime < fadeDuration)
		{
			elapsedTime += Time.deltaTime;                        // 経過時間を増やす
			float t = Mathf.Clamp01(elapsedTime / fadeDuration);  // フェードの進行度を計算
			fadePanel.color = Color.Lerp(startColor, endColor, t); // パネルの色を変更してフェードアウト
			yield return null;                                     // 1フレーム待機
		}

		fadePanel.color = endColor;  // フェードが完了したら最終色に設定
		SceneManager.LoadScene("Title");

	}
	private void PlaySE(AudioClip clip)
	{
		if (audioSource != null && clip != null)
		{
			audioSource.PlayOneShot(clip);
		}
	}
}



