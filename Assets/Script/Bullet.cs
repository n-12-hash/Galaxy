using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	void OnTriggerEnter(Collider collision)
	{

		if (collision.gameObject.CompareTag("Monster")) //�^�O��Monster�̃I�u�W�F�N�g�ƏՓ˂����ꍇ
		{
			Destroy(collision.gameObject); //�Փ˂������������
			Destroy(gameObject); //�e������
		}
	}
}
