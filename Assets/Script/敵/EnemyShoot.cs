using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyShoot : MonoBehaviour
{
	[SerializeField] AudioMixer audioMixer;
	public AudioSource audioSource;
	public GameObject shellPrefab; // �e
	[SerializeField] private float bulletSpeed;
	[SerializeField] private float fireRate; // ���ˊԊu�i�b�j
	[SerializeField] private float nextFireTime; // ���ɔ��˂ł��鎞��

	/*void Start()
	{
		// �w�肵�����\�b�h���A�w�肵�����ԁi�P�ʁG�b�j����A�w�肵���Ԋu�i�P�ʁG�b�j�ŌJ��Ԃ����s����B
		InvokeRepeating("Shot", 0f, 1f);
	}*/

	void Update()
	{
		if (Time.time >= nextFireTime)
		{
			Shoot();
			nextFireTime = Time.time + 1f / fireRate;
		}
	}

	void Shoot()
	{
		// �e�𐶐�
		GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);
		// �e�ɗ͂�������
		Rigidbody shellRb = shell.GetComponent<Rigidbody>();
		// �e���͎��R�ɐݒ�
		shellRb.AddForce(transform.forward * bulletSpeed);

		// ���ˉ����o��
		AudioSource audioSource;

		// �T�b��ɖC�e��j�󂷂�
		Destroy(shell, 5.0f);
	}
}


