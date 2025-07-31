using UnityEngine;

public class Shoot : MonoBehaviour
{
	[SerializeField] private AudioClip shootSE;
	public AudioSource audioSource;
	public GameObject PistolBullet; // �e
	public float bulletSpeed = 500f; // �e�̑��x

	private float fireRate = 0.2f;   // ���ˊԊu�i�b�j
	private float nextFireTime = 0f; // ���ɔ��˂ł��鎞��

	void Update()
	{
		// �{�^�������������Ă���ԁA���ˏ������J��Ԃ�
		if (Input.GetKeyDown(KeyCode.JoystickButton4) || Input.GetKeyDown(KeyCode.JoystickButton5))
		{
			if (Time.time >= nextFireTime && !Pause.isPaused)
			{
				PlayerShoot();
				nextFireTime = Time.time + fireRate;
			}
		}
	}

	void PlayerShoot()
	{
		// �e�𐶐�
		GameObject newBullet = Instantiate(PistolBullet, transform.position, Quaternion.identity);
		Rigidbody rb = newBullet.GetComponent<Rigidbody>();

		// �e���L�����̑O���֔�΂�
		rb.AddForce(transform.forward * bulletSpeed);

		// ���ˉ�
		PlaySE(shootSE);

		// 3�b��ɒe���폜
		Destroy(newBullet, 3f);
	}

	void PlaySE(AudioClip clip)
	{
		if (audioSource != null && clip != null)
		{
			audioSource.PlayOneShot(clip);
		}
	}
}
