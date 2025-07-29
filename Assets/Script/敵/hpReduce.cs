using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HpReduce : MonoBehaviour
{

	//爆発のPrefabを宣言
	[SerializeField] GameObject explosionPrefab;
	[SerializeField] private AudioClip SE;
	public AudioSource audioSource;
	//[SerializeField] AudioClip se;
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
			Destroy(gameObject); // このオブジェクトを消す
			PlaySE(SE);
			GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
			Destroy(explosion, 2.0f); //2秒後に爆発を削除

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
