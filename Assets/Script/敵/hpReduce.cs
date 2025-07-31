using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HpReduce : MonoBehaviour
{

	//������Prefab��錾
	[SerializeField] GameObject explosionPrefab;
	[SerializeField] private AudioClip SE;
	public AudioSource audioSource;

	//[SerializeField] AudioClip se;
	//�@�G��MaxHP
	[SerializeField]
	private int maxHp;
	//�@�G��HP
	[SerializeField]
	private int hp;
	//�@HP�\���pUI
	[SerializeField]
	private GameObject HPUI;

	//�@HP�\���p�X���C�_�[
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
			Debug.Log("��������" + hpSlider.value);
			Destroy(Collision.gameObject);
		}

		if (hp <= 0)
		{
			Debug.Log("1");
			GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
			var expAudio = explosion.AddComponent<AudioSource>();
			expAudio.PlayOneShot(SE);
			// explosion �� AutoDestroy �X�N���v�g��t���Đ��b��ɔj��
			Destroy(gameObject); // �G�͂��Ƃ���j��

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
