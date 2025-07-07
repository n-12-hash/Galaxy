using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
	[SerializeField] GameObject explosionPrefab;    //爆発のPrefabを宣言
	[SerializeField] AudioClip se;                  // 効果音

	private Collider objectCollider;
	private Rigidbody rb;

	void Start()
	{
		objectCollider = GetComponent<SphereCollider>();
		objectCollider.isTrigger = true; //Triggerとして扱う
		rb = GetComponent<Rigidbody>();
		rb.useGravity = false; //重力を無効にする
	}


	void OnTriggerEnter(Collider collision)
	{

		if (collision.gameObject.CompareTag("Monster")) //タグがMonsterのオブジェクトと衝突した場合
		{
			Destroy(collision.gameObject); //衝突した相手を消す
			Destroy(gameObject); //弾を消す
			AudioSource.PlayClipAtPoint(se, transform.position);
			GameObject explosion = Instantiate(explosionPrefab,
			  transform.position, Quaternion.identity);
			Destroy(explosion, 2.0f);       //2秒後にexplosionを削除
		}


	}
}
