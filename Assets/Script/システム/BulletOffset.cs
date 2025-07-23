using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOffset : MonoBehaviour
{
	void OnTriggerExit(Collider Collision)
	{
		if (Collision.gameObject.tag == "Bullet")
		{
			Destroy(Collision.gameObject);
			Destroy(gameObject); //このオブジェクトを消す
		}
	}
}
