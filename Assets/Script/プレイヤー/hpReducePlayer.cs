using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HpReducePlayer: MonoBehaviour
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

		if (hp == 0)
		{
			SceneManager.LoadScene("GameOver");
			//AudioSource.PlayClipAtPoint(se, transform.position);//爆発させる
			//Destroy(gameObject); //このオブジェクトを消す
			/*GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
			Destroy(explosion, 2.0f); //2秒後に爆発を削除*/
		}

	}


	// Update is called once per frame
	void Update()
	{

	}

}
