using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HpReduceBoss : MonoBehaviour
{
	//爆発のPrefabを宣言
	[SerializeField] GameObject explosionPrefab;
	[SerializeField] private AudioClip SE;
	public AudioSource audioSource;
	//　敵のMaxHP
	[SerializeField]
	private int maxHp;
	//　敵のHP
	[SerializeField]
	private int hp;
	//　HP表示用UI
	[SerializeField]
	private GameObject HPUI;
	//　HP表示用スライダー
	private Slider hpSlider;
	public GameObject goal; // ゴールオブジェクト


	// Start is called before the first frame update
	void Start()
	{
		//hpSlider.value = 100;
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
		if (Collision.gameObject.tag == "Bullet"){
			hp -= 10;
			hpSlider.value = hp / (float)maxHp;
			Debug.Log("当たった" + hpSlider.value);
			Destroy(Collision.gameObject);
		}

		if (hp <= 0)
		{
			Destroy(gameObject); //このオブジェクトを消す
			PlaySE(SE);//爆発させる
			GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
			Destroy(explosion, 2.0f); //2秒後に爆発を削除
		}

	}
	void OnDestroy()
	{
		// ボスが倒された時に実行される処理
		if (goal != null)
		{
			goal.SetActive(true); // ゴールを表示
		}
	}

	private void PlaySE(AudioClip clip)
	{
		if (audioSource != null && clip != null)
		{
			audioSource.PlayOneShot(clip);
		}
	}
}
