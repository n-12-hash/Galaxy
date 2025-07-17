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
	[SerializeField] private float fireRate; // ���ˊԊu�i�b�j
	[SerializeField] private float nextFireTime; // ���ɔ��˂ł��鎞��
	[SerializeField] private float bulletSpeed;
	private float time = 1.0f;
	public Transform Target;
	//public Transform initialposition;//random;
	NavMeshAgent agent;
	bool sensor;


	// Start is called before the first frame update
	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
	}

	// Update is called once per frame
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

}

