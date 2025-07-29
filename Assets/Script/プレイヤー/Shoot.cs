using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditorInternal.ReorderableList;

public class Shoot : MonoBehaviour
{

	private Animator animator;  // �A�j���[�V����
	[SerializeField] private AudioClip shootSE;
	public AudioSource audioSource;
	public GameObject PistolBullet; // �e
	public float bulletSpeed; //�e�̑��x
	private float fireRate = 0.5f;   // ���ˊԊu
	private float nextFireTime = 5.0f; // ���ɔ��˂ł��鎞��
	Move script; //�Q�Ƃ���X�N���v�g

	/*private void Start()
	{
		if (volumeSlider != null)
		{
			volumeSlider.onValueChanged.AddListener((value) =>
			{
				// value��0�`1�̒l�����҂���B�����ۏ؂��邽�߂̏���
				value = Mathf.Clamp01(value);

				float decibel = 20f * Mathf.Log10(value);
				decibel = Mathf.Clamp(decibel, -80f, 0f);
				audioMixer.SetFloat(audioSource, decibel);
			});
		}
	}*/

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

		if (Pause.isPaused) return; // �|�[�Y���͉������Ȃ�

		//�e�𐶐�
		GameObject newbullet = Instantiate(PistolBullet, this.transform.position, Quaternion.identity);
		Rigidbody bulletRigidbody = newbullet.GetComponent<Rigidbody>();
		//�L�����N�^�[�������Ă�������ɒe�ɗ͂�������	
		bulletRigidbody.AddForce(this.transform.forward * bulletSpeed);
		// ���ˉ����o��
		PlaySE(shootSE);
		//3�b��ɒe������
		Destroy(newbullet, 3);
	}

	private void PlaySE(AudioClip clip)
	{
		if (audioSource != null && clip != null)
		{
			audioSource.PlayOneShot(clip);
		}
	}
}
