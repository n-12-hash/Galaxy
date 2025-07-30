using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EnemyBulletScript : MonoBehaviour
{
	[SerializeField] GameObject player;
	[SerializeField] GameObject bullet;
	[SerializeField] private AudioClip shootSE;
	public AudioSource audioSource;
	[SerializeField] private float fireRate; // ���ˊԊu�i�b�j
	[SerializeField] private float nextFireTime; // ���ɔ��˂ł��鎞��
	[SerializeField] private float bulletSpeed;
	private float time = 1.0f;
	public Transform Target;
	//public Transform initialposition;//random;
	bool sensor;


	// Start is called before the first frame update

	// Update is called once per frame

	void Start()
	{
		if (player == null)
		{
			player = GameObject.FindWithTag("Player");
			if (player == null)
			{
				Debug.LogError("Player ��������܂���I�^�O 'Player' �����I�u�W�F�N�g���V�[���ɔz�u���Ă��������B");
			}
		}
	}


	void Update()
	{

		if (Pause.isPaused) return; // �|�[�Y���͉������Ȃ�
		if (sensor == true)
		{
			transform.LookAt(player.transform);
			time -= Time.deltaTime;
			if (Time.time >= nextFireTime)
			{
				BallShoot();
				nextFireTime = Time.time + 1f / fireRate;
			}
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
		// ���ˉ����o��
		PlaySE(shootSE);
		//3�b��ɒe������
		Destroy(newbullet, 3);
	}

	public void Syageki()
	{
		sensor = true;
	}

	public void Stop()
	{
		sensor = false;
	}
	private void PlaySE(AudioClip clip)
	{
		if (audioSource != null && clip != null)
		{
			audioSource.PlayOneShot(clip);
		}
	}

}

