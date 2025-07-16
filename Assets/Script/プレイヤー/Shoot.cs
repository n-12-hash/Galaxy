using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{

	private Animator animator;  // �A�j���[�V����
	public AudioClip sound;
	public GameObject PistolBullet; // �e
	public float fireRate = 2.0f;   // ���ˊԊu
	public float bulletSpeed; //�e�̑��x
	[SerializeField] private float nextFireTime; // ���ɔ��˂ł��鎞��
	Move script; //�Q�Ƃ���X�N���v�g


	void Update()
	{
		if (/*animator.SetBool("Walk_Anim", true) &&*/ Input.GetKeyDown(KeyCode.JoystickButton4) || Input.GetKeyDown(KeyCode.JoystickButton5))
		{
			PlayerShoot();
			nextFireTime = Time.time + 1f / fireRate;
		}

	}

	void PlayerShoot()
	{
		// ���ˉ����o��
		AudioSource.PlayClipAtPoint(sound, transform.position);
		//�e�𐶐�
		GameObject newbullet = Instantiate(PistolBullet, this.transform.position, Quaternion.identity);
		Rigidbody bulletRigidbody = newbullet.GetComponent<Rigidbody>();
		//�L�����N�^�[�������Ă�������ɒe�ɗ͂�������	
		bulletRigidbody.AddForce(this.transform.forward * bulletSpeed);
		//3�b��ɒe������
		Destroy(newbullet, 3);
	}

}
