using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class HpReduce : MonoBehaviour
{
	//爆発のPrefabを宣言
	[SerializeField] GameObject explosionPrefab;
	[SerializeField] AudioClip se;
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


	/// <summary> マテリアルの色パラメータのID </summary>
	private static readonly int PROPERTY_COLOR = Shader.PropertyToID("_Color");

	/// <summary> モデルのRenderer </summary>
	[SerializeField]
	private Renderer _renderer;

	/// <summary> モデルのマテリアルの複製 </summary>
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
		// materialにアクセスして自動生成されるマテリアルを保持
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
			Debug.Log("当たった" + hpSlider.value);
			Destroy(Collision.gameObject);
			//HitFadeBlink(Color.red);
		}

		if (hp <= 0)
		{
			Destroy(gameObject); //このオブジェクトを消す
			AudioSource.PlayClipAtPoint(se, transform.position);//爆発させる
			GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
			Destroy(explosion, 2.0f); //2秒後に爆発を削除
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
