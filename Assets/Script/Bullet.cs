using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] GameObject explosionPrefab;    //������Prefab��錾
	[SerializeField] AudioClip se;                  // ���ʉ�
	void OnTriggerEnter(Collider collision)
	{

		if (collision.gameObject.CompareTag("Monster")) //�^�O��Monster�̃I�u�W�F�N�g�ƏՓ˂����ꍇ
		{
			Destroy(collision.gameObject); //�Փ˂������������
			Destroy(gameObject); //�e������
			AudioSource.PlayClipAtPoint(se, transform.position);
			GameObject explosion = Instantiate(explosionPrefab,
			  transform.position, Quaternion.identity);
			Destroy(explosion, 2.0f);       //2�b���explosion���폜
		}
	}
}
