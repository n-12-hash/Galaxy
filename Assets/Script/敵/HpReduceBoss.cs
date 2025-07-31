using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HpReduceBoss : MonoBehaviour
{
	//������Prefab��錾
	[SerializeField] GameObject explosionPrefab;
	[SerializeField] private AudioClip SE;
	public AudioSource audioSource;
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
	private Slider hpSlider;
	public GameObject goal; // �S�[���I�u�W�F�N�g


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
			GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
			var expAudio = explosion.AddComponent<AudioSource>();
			expAudio.PlayOneShot(SE);
			// explosion �� AutoDestroy �X�N���v�g��t���Đ��b��ɔj��
			Destroy(gameObject); // �G�͂��Ƃ���j��

		}

	}
	void OnDestroy()
	{
		// �{�X���|���ꂽ���Ɏ��s����鏈��
		if (goal != null)
		{
			goal.SetActive(true); // �S�[����\��
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
