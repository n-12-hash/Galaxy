using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyShoot1 : MonoBehaviour
{
	[SerializeField] GameObject player;
	[SerializeField] GameObject bullet;
	[SerializeField] private float fireRate; // ���ˊԊu�i�b�j
	[SerializeField] private float nextFireTime; // ���ɔ��˂ł��鎞��
	[SerializeField] private float bulletSpeed;
	private float time = 1.0f;

	void Update()
	{
		transform.LookAt(player.transform);
		time -= Time.deltaTime;
		if (Time.time >= nextFireTime)
		{
			BallShoot();
			nextFireTime = Time.time + 1f / fireRate;
		}
	}

	void BallShoot()
	{
		//�e�𐶐�
		GameObject newbullet = Instantiate(bullet, transform.position, Quaternion.identity);
		newbullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
		// �e�ɗ͂�������
		Rigidbody bulletRigidbod = newbullet.GetComponent<Rigidbody>();
		// �e���͎��R�ɐݒ�
		bulletRigidbod.AddForce(transform.forward * bulletSpeed);
		Destroy(newbullet, 3); //3�b��ɒe������


	}
}
