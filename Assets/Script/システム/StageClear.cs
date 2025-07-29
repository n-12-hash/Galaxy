using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageClear : MonoBehaviour
{
	// フェード
	public Image fadePanel;      // フェード用のUIパネル（Image）
	public float fadeDuration;   // フェードの完了にかかる時間

	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.CompareTag("Player")) 
		{
			StartCoroutine(FadeOutAndLoadScene());
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
		SceneController.CurrentSceneName();
		SceneManager.LoadScene("GameClear");
	}
}
