using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HpReducePlayer: MonoBehaviour
{
	//コライダーをオンオフするためのBoxCollider
	SphereCollider Muteki;
	//爆発のPrefabを宣言
	[SerializeField] GameObject explosionPrefab;
	[SerializeField] AudioClip se;
	//　自分のMaxHP
	[SerializeField]
	private int maxHp;
	//　自分のHP
	[SerializeField]
	private int hp;
	//　HP表示用UI
	[SerializeField]
	private GameObject HPUI;
	//　HP表示用スライダー
	private Slider hpSlider;
	// フェード
	public Image fadePanel;      // フェード用のUIパネル（Image）
	public float fadeDuration;   // フェードの完了にかかる時間

	Renderer[] renderers;

	private void Start()
	{
		renderers = GetComponentsInChildren<Renderer>();

		hp = maxHp;
		hpSlider = HPUI.transform.Find("HPBar").GetComponent<Slider>();
		hpSlider.value = 1f;

		fadePanel.enabled = false;
		Color c = fadePanel.color;
		c.a = 0f;
		fadePanel.color = c;
	}


	public void SetHp(int hp)
	{
		this.hp = hp;
	}
	void OnTriggerExit(Collider Collision)
	{
		if (Collision.gameObject.tag == "EnemyBullet"){
			hp -= 10;
			hpSlider.value = hp / (float)maxHp;
			Debug.Log("当たった" + hpSlider.value);
			Destroy(Collision.gameObject);
			StartCoroutine(DamageBlink());
			/*//当たり判定オフ
			Muteki.enabled = false;*/
		}

		if (hp == 0)
		{
			AudioSource.PlayClipAtPoint(se, transform.position);//爆発させる
			GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
			Destroy(explosion, 2.0f); //2秒後に爆発を削除
			StartCoroutine(FadeOutAndLoadScene());
		}
	}

	public IEnumerator DamageBlink()
	{
		float blinkInterval = 0.1f; // 点滅間隔
		int blinkCount = 10; // 点滅回数
		for (int i = 0; i < blinkCount * 2; i++)
		{
			foreach (Renderer renderer in renderers)
			{
				renderer.enabled = !renderer.enabled;
			}
			yield return new WaitForSeconds(blinkInterval);
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
		SceneManager.LoadScene("GameOver");
	}
}

