using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpReduce : MonoBehaviour
{
	//������Prefab��錾
	[SerializeField] GameObject explosionPrefab;
	[SerializeField] AudioClip se;
	//�@�G��MaxHP
	[SerializeField]
	private int maxHp = 100;
	//�@�G��HP
	[SerializeField]
	private int hp;
	//�@�G�̍U����
	[SerializeField]
	private int attackPower = 1;
	//�@HP�\���pUI
	[SerializeField]
	private GameObject HPUI;
	//�@HP�\���p�X���C�_�[
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

		//�@HP�\���pUI�̃A�b�v�f�[�g
		UpdateHPValue();
		if (hp <= 0)
		{
			//�@HP�\���pUI���\���ɂ���
			HideStatusUI();
		}
	}
	void OnTriggerExit(Collider Collision)
	{
		if (Collision.gameObject.tag == "Bullet"){
			hpSlider.value -= 1;
			Debug.Log("��������");
		}

		if (hp <= 0)
		{
			Destroy(gameObject); //���̃I�u�W�F�N�g������
			AudioSource.PlayClipAtPoint(se, transform.position);//����������
			GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
			Destroy(explosion, 2.0f); //2�b��ɔ������폜
		}

	}
	// Update is called once per frame
	void Update()
	{

	}

}
