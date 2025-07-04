using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] GameObject explosionPrefab;    //爆発のPrefabを宣言
	[SerializeField] AudioClip se;                  // 効果音
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
