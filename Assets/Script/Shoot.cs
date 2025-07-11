using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{

	public AudioClip sound;
	public GameObject PistolBullet; // �e
	public float fireRate = 2.0f;   // ���ˊԊu
	public float bulletSpeed; //�e�̑��x


	void Start()
	{

	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.JoystickButton4) || Input.GetKeyDown(KeyCode.JoystickButton5) )
		{
			// ���ˉ����o��
			AudioSource.PlayClipAtPoint(sound, transform.position);
			//�e�𐶐�
			GameObject newbullet = Instantiate(PistolBullet, this.transform.position, Quaternion.identity);//�e�𐶐�
			Rigidbody bulletRigidbody = newbullet.GetComponent<Rigidbody>();
			bulletRigidbody.AddForce(this.transform.forward * bulletSpeed); //�L�����N�^�[�������Ă�������ɒe�ɗ͂�������	
			Destroy(newbullet, 3); //3�b��ɒe������

		}

	}

}
