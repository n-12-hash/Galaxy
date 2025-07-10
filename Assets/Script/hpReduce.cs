using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpReduce : MonoBehaviour
{
	//爆発のPrefabを宣言
	[SerializeField] GameObject explosionPrefab;
	[SerializeField] AudioClip se;
	//　敵のMaxHP
	[SerializeField]
	private int maxHp = 100;
	//　敵のHP
	[SerializeField]
	private int hp;
	//　敵の攻撃力
	[SerializeField]
	private int attackPower = 1;
	//　HP表示用UI
	[SerializeField]
	private GameObject HPUI;
	//　HP表示用スライダー
	private Slider hpSlider;

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

		//　HP表示用UIのアップデート
		UpdateHPValue();
		if (hp <= 0)
		{
			//　HP表示用UIを非表示にする
			HideStatusUI();
		}
	}
	void OnTriggerExit(Collider Collision)
	{
		if (Collision.gameObject.tag == "Bullet"){
			hpSlider.value -= 1;
			Debug.Log("当たった");
		}

		if (hp <= 0)
		{
			Destroy(gameObject); //このオブジェクトを消す
			AudioSource.PlayClipAtPoint(se, transform.position);//爆発させる
			GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
			Destroy(explosion, 2.0f); //2秒後に爆発を削除
		}

	}
	// Update is called once per frame
	void Update()
	{

	}

}
