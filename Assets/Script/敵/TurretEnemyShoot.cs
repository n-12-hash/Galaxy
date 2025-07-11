using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemyShoot : MonoBehaviour
{
	[SerializeField] GameObject player;
	[SerializeField] GameObject bullet;
	private float bulletSpeed = 20.0f;
	private float time = 10.0f;

	void Update()
	{
		transform.LookAt(player.transform);
		time -= Time.deltaTime;
		if (time <= 0)
		{
			BallShot();
			time = 1.0f;
		}
	}

	void BallShot()
	{
		GameObject newbullet = Instantiate(bullet, transform.position, Quaternion.identity);//�e�𐶐�
		newbullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
		Rigidbody bulletRigidbody = newbullet.GetComponent<Rigidbody>();
		bulletRigidbody.AddForce(transform.forward * bulletSpeed); //�L�����N�^�[�������Ă�������ɒe�ɗ͂�������*/
		Destroy(newbullet, 3); //3�b��ɒe������
	}
}
