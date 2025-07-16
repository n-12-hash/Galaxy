using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class hpReducePlayer: MonoBehaviour
{
	//������Prefab��錾
	[SerializeField] GameObject explosionPrefab;
	[SerializeField] AudioClip se;
	//�@������MaxHP
	[SerializeField]
	private int maxHp;
	//�@������HP
	[SerializeField]
	private int hp;
	//�@HP�\���pUI
	[SerializeField]
	private GameObject HPUI;
	//�@HP�\���p�X���C�_�[
	private Slider hpSlider;
	// �Q�[���I�[�o�[����
	[SerializeField] private GameObject pauseUI;
	public static bool isPaused = false; // �� static �ɕύX
	[SerializeField] private GameObject optionFirst;

	// Start is called before the first frame update
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
			Debug.Log("��������" + hpSlider.value);
			Destroy(Collision.gameObject);
		}

		if (hp <= 0)
		{
			Destroy(gameObject); //���̃I�u�W�F�N�g������
			AudioSource.PlayClipAtPoint(se, transform.position);//����������
			GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
			Destroy(explosion, 2.0f); //2�b��ɔ������폜
			TogglePause();
		}

	}

	public void TogglePause()
	{
		isPaused = !isPaused;
		if (isPaused)
		{
			EventSystem.current.SetSelectedGameObject(null);
			EventSystem.current.SetSelectedGameObject(optionFirst);
		}
		pauseUI.SetActive(isPaused);

	}
	// Update is called once per frame
	void Update()
	{

	}

}
