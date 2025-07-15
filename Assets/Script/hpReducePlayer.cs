using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class hpReducePlayer: MonoBehaviour
{
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
	// ゲームオーバー処理
	[SerializeField] private GameObject pauseUI;
	public static bool isPaused = false; // ← static に変更
	[SerializeField] private GameObject optionFirst;

	// Start is called before the first frame update
	void Start()
	{
		hp = maxHp;
		hpSlider = HPUI.transform.Find("HPBar").GetComponent<Slider>();
		hpSlider.value = 1f;
	}


	public void SetHp(int hp)
	{
		this.hp = hp;
	}
	void OnTriggerExit(Collider Collision)
	{
		if (Collision.gameObject.gameObject.tag == "EnemyBullet"){
			hp -= 10;
			hpSlider.value = hp / (float)maxHp;
			Debug.Log("当たった" + hpSlider.value);
			Destroy(Collision.gameObject);
		}

		if (hp <= 0)
		{
			Destroy(gameObject); //このオブジェクトを消す
			AudioSource.PlayClipAtPoint(se, transform.position);//爆発させる
			GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
			Destroy(explosion, 2.0f); //2秒後に爆発を削除
			TogglePause();
		}

	}

	public void TogglePause()
	{
		isPaused = !isPaused;
		if (isPaused)
		{
			EventSystem.current.SetSelectedGameObject(null);
			EventSystem.current.SetSelectedGameObject(optionFirst);
		}
		pauseUI.SetActive(isPaused);

	}
	// Update is called once per frame
	void Update()
	{

	}

}
