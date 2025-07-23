using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class HpReduce : MonoBehaviour
{
	//������Prefab��錾
	[SerializeField] GameObject explosionPrefab;
	[SerializeField] AudioClip se;
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


	/// <summary> �}�e���A���̐F�p�����[�^��ID </summary>
	private static readonly int PROPERTY_COLOR = Shader.PropertyToID("_Color");

	/// <summary> ���f����Renderer </summary>
	[SerializeField]
	private Renderer _renderer;

	/// <summary> ���f���̃}�e���A���̕��� </summary>
	private Material _material;

	private DG.Tweening.Sequence _seq;



	// Start is called before the first frame update
	void Start()
	{
		//hpSlider.value = 100;
		hp = maxHp;
		hpSlider = HPUI.transform.Find("HPBar").GetComponent<Slider>();
		hpSlider.value = 1f;
	}

	private void Awake()
	{
		// material�ɃA�N�Z�X���Ď������������}�e���A����ێ�
		_material = _renderer.material;
	}




	public void SetHp(int hp)
	{
		this.hp = hp;
	}
	void OnTriggerExit(Collider Collision)
	{
		if (Collision.gameObject.tag == "Bullet"){
			hp -= 10;
			hpSlider.value = hp / (float)maxHp;
			Debug.Log("��������" + hpSlider.value);
			Destroy(Collision.gameObject);
			//HitFadeBlink(Color.red);
		}

		if (hp <= 0)
		{
			Destroy(gameObject); //���̃I�u�W�F�N�g������
			AudioSource.PlayClipAtPoint(se, transform.position);//����������
			GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
			Destroy(explosion, 2.0f); //2�b��ɔ������폜
		}

	}


	private void HitFadeBlink(Color color)
	{
		_seq?.Kill();
		_seq = DOTween.Sequence();
		_seq.Append(DOTween.To(() => Color.white, c => _material.SetColor(PROPERTY_COLOR, c), color, 0.1f));
		_seq.Append(DOTween.To(() => color, c => _material.SetColor(PROPERTY_COLOR, c), Color.white, 0.1f));
		_seq.Play();
	}

}
