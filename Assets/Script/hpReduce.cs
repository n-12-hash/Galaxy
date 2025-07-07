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
	private Monster enemy;
	//　HP表示用UI
	[SerializeField]
	private GameObject HPUI;
	//　HP表示用スライダー
	public Slider hpSlider;

	// Start is called before the first frame update
	void Start()
	{
		enemy = GetComponent<Monster>();
		hp = maxHp;
		hpSlider = HPUI.transform.Find("HPBar").GetComponent<Slider>();
		hpSlider.value = 1f;
	}

	void OnTriggerExit(Collider collision)
	{
		/*if (collision.gameObject.tag == "Bullet")
		{
			hpSlider.value -= 10;
		}*/

	}


	public void SetHp(int hp)
	{
		this.hp = hp;

		//　HP表示用UIのアップデート
		UpdateHPValue();
		void OnTriggerEnter(Collider collision)
		{
			if (collision.gameObject.tag == "Bullet")
			{
				hpSlider.value -= 10;
			}

			if (hp <= 0 && (collision.gameObject.CompareTag("Bullet")))  
			{
				//　HP表示用UIを非表示にする
				HideStatusUI();
				Destroy(collision.gameObject); //このオブジェクトを消す
				AudioSource.PlayClipAtPoint(se, transform.position);
				GameObject explosion = Instantiate(explosionPrefab,
				  transform.position, Quaternion.identity);
				Destroy(explosion, 2.0f);       //2秒後にexplosionを削除
			}
		}
	}

	public int GetHp()
	{
		return hp;
	}

	public int GetMaxHp()
	{
		return maxHp;
	}


	//　死んだらHPUIを非表示にする
	public void HideStatusUI()
	{
		HPUI.SetActive(false);
	}

	public void UpdateHPValue()
	{
		hpSlider.value = (float)GetHp() / (float)GetMaxHp();
	}
}
