using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{


	public GameObject PistolBullet; // �e
	public float fireRate = 0.5f;   // ���ˊԊu
	public float bulletSpeed; //�e�̑��x


	void Start()
	{

	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.JoystickButton4) || Input.GetKeyDown(KeyCode.JoystickButton5) )
		{
			//�e�𐶐�
			GameObject Bullet = Instantiate(PistolBullet, this.transform.position, Quaternion.identity);//�e�𐶐�
			Rigidbody bulletRigidbody = PistolBullet.GetComponent<Rigidbody>();
			bulletRigidbody.AddForce(this.transform.forward * bulletSpeed); //�L�����N�^�[�������Ă�������ɒe�ɗ͂�������	
			Destroy(Bullet, 3); //3�b��ɒe������

		}

	}

}
