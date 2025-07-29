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
	public Image fadePanel;             // フェード用のUIパネル（Image）
	public float fadeDuration;   // フェードの完了にかかる時間
	public static string sceneName;

	// 「このメソッドが実行された時に開いているシーンの名前」を取得する。
	// 今回の場合は、ゲームオーバーの条件が揃った時に、このメソッドを呼び出す。
	public static void CurrentSceneName()
	{
		sceneName = SceneManager.GetActiveScene().name;
		Debug.Log(sceneName);
	}



	// 上記のメソッドで取得されたシーンに戻る。
	// 今回の場合は、コンティニューボタンを押した時にこのメソッドを実行する。
	public  void BackToBeforeScene()
	{
		StartCoroutine(FadeOutAndLoadScene());
		PlaySE(SE);
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