using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemyShoot3D : MonoBehaviour
{
	public GameObject shellPrefab; // �e�̃v���n�u
	public float fireRate = 1f; // ���ˊԊu�i�b�j
	public float shellSpeed = 5f; // �e�̑��x
	public Transform bulletPosition; // �e�̔��ˈʒu

	private float nextFireTime = 0f;

	void Update()
	{
		// ��莞�Ԃ��Ƃɒe�𔭎�
		if (Time.time >= nextFireTime)
		{
			Shoot();
			nextFireTime = Time.time + fireRate;
		}
	}

	void Shoot()
	{
		// �e�𐶐�
		GameObject shell = Instantiate(shellPrefab, bulletPosition.position, Quaternion.identity);
		// �e�ɗ͂������đO���֔���
		Rigidbody rb = shell.GetComponent<Rigidbody>();
		if (rb != null)
		{
			rb.velocity = transform.forward * shellSpeed; // �G�̌����ɑ��x��ݒ�
		}
	}
}


