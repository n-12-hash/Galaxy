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
	private Monster enemy;
	//�@HP�\���pUI
	[SerializeField]
	private GameObject HPUI;
	//�@HP�\���p�X���C�_�[
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

		//�@HP�\���pUI�̃A�b�v�f�[�g
		UpdateHPValue();
		void OnTriggerEnter(Collider collision)
		{
			if (collision.gameObject.tag == "Bullet")
			{
				hpSlider.value -= 10;
			}

			if (hp <= 0 && (collision.gameObject.CompareTag("Bullet")))  
			{
				//�@HP�\���pUI���\���ɂ���
				HideStatusUI();
				Destroy(collision.gameObject); //���̃I�u�W�F�N�g������
				AudioSource.PlayClipAtPoint(se, transform.position);
				GameObject explosion = Instantiate(explosionPrefab,
				  transform.position, Quaternion.identity);
				Destroy(explosion, 2.0f);       //2�b���explosion���폜
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


	//�@���񂾂�HPUI���\���ɂ���
	public void HideStatusUI()
	{
		HPUI.SetActive(false);
	}

	public void UpdateHPValue()
	{
		hpSlider.value = (float)GetHp() / (float)GetMaxHp();
	}
}
