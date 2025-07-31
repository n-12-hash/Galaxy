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
	[SerializeField] private Slider hpSlider;


	void Start()
	{
		hpSlider = HPUI.GetComponent<Slider>();
	}

	public void SetHp(int hp)
	{
		Debug.Log("2");
		this.hp = hp;
	}
	void OnTriggerEnter(Collider Collision)
	{
		if (Collision.gameObject.tag == "Bullet"){
			hp -= 10;
			hpSlider.value = hp / (float)maxHp;
			Debug.Log("当たった" + hpSlider.value);
			Destroy(Collision.gameObject);
		}

		if (hp <= 0)
		{
			Debug.Log("1");
			GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
			var expAudio = explosion.AddComponent<AudioSource>();
			expAudio.PlayOneShot(SE);
			// explosion に AutoDestroy スクリプトを付けて数秒後に破棄
			Destroy(gameObject); // 敵はあとから破棄

		}

	}

	public void PlaySE(AudioClip clip)
	{
		if (audioSource != null && audioSource.enabled && audioSource.gameObject.activeInHierarchy && clip != null)
		{
			audioSource.PlayOneShot(clip);
		}
	}


}
