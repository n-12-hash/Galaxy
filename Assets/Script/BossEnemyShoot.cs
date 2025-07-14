using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyShoot : MonoBehaviour
{
	[SerializeField] GameObject bullet;
	[SerializeField] private float fireRate; // ���ˊԊu�i�b�j
	[SerializeField] private float nextFireTime; // ���ɔ��˂ł��鎞��
	[SerializeField] private float bulletSpeed;
	private float time = 1.0f;
	public float distance; // �X���C�h���钷��
	public float length; // �������鋗��
	Vector3 startPos; // �����ʒu���W
	Transform player; // �v���C���[���W


	// Use this for initialization
	void Start()
	{
		player = GameObject.Find("Player").transform; // Player�Ƃ������O�̃I�u�W�F�N�g���擾
		startPos = transform.position; // �����ʒu����
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 pos = transform.position; // ���݂̍��W

		// �v���C���[�����̋����ɋ߂Â�����
		if (Vector3.Distance(player.position, startPos) <= length)
		{
			transform.LookAt(player.transform);
			time -= Time.deltaTime;
			if (Time.time >= nextFireTime)
			{
				BallShoot();
				nextFireTime = Time.time + 1f / fireRate;
			}
		}
		else
		{

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

		transform.position = pos; // ���W���w��
	}
}
