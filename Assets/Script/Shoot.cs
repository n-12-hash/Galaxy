using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

	public float bulletSpeed; //�e�̑��x
	public GameObject PistolBullet; // �e
	public float fireRate = 0.5f;   // ���ˊԊu
	private float speed = 300;


	private Collider objectCollider;
	private Rigidbody rb;

	void Start()
	{
		objectCollider = GetComponent<SphereCollider>();
		objectCollider.isTrigger = true; //Trigger�Ƃ��Ĉ���
		rb = GetComponent<Rigidbody>();
		rb.useGravity = false; //�d�͂𖳌��ɂ���
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.JoystickButton4) || Input.GetKeyDown(KeyCode.JoystickButton5) )
		{
			//�e�𐶐�
			GameObject Bullet = Instantiate(PistolBullet, this.transform.position, Quaternion.identity);
			Rigidbody bulletRigidbody = PistolBullet.GetComponent<Rigidbody>();

			//3�b��ɒe������	
			Destroy(Bullet, 3);

			// �e�ɑ��x��^����
			Rigidbody rb = Bullet.GetComponent<Rigidbody>();
			if (rb != null)
			{
				rb.velocity = this.transform.forward * bulletSpeed;
			}

		}

	}


}
