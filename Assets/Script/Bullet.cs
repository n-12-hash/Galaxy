using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	void OnTriggerEnter(Collider collision)
	{

		if (collision.gameObject.CompareTag("Monster")) //タグがMonsterのオブジェクトと衝突した場合
		{
			Destroy(collision.gameObject); //衝突した相手を消す
			Destroy(gameObject); //弾を消す
		}
	}
}
