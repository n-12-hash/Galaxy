using UnityEngine;

public class Shoot : MonoBehaviour
{
	[SerializeField] private AudioClip shootSE;
	public AudioSource audioSource;
	public GameObject PistolBullet;
	public float bulletSpeed = 500f;

	private float fireRate = 0.2f;
	private float nextFireTime = 0f;

	private Animator playerAnimator;

	void Start()
	{
		// Player��Animator���擾
		GameObject player = GameObject.FindWithTag("Player");
		if (player != null)
		{
			playerAnimator = player.GetComponent<Animator>();
		}
	}

	void Update()
	{
		// ���C�����i����̃A�j���[�V�������͖����j
		if (playerAnimator != null)
		{
			var animState = playerAnimator.GetCurrentAnimatorStateInfo(0);
			if (animState.IsName("anim_open") || animState.IsName("anim_open_GoToRoll"))
			{
				return; // �A�j���[�V�������Ȃ̂Ŕ��C���Ȃ�
			}
		}

		// ���C����
		if ((Input.GetKeyDown(KeyCode.JoystickButton4) || Input.GetKeyDown(KeyCode.JoystickButton5)) && Time.time >= nextFireTime && !Pause.isPaused)
		{
			PlayerShoot();
			nextFireTime = Time.time + fireRate;
		}
	}

	void PlayerShoot()
	{
		GameObject newBullet = Instantiate(PistolBullet, transform.position, Quaternion.identity);
		Rigidbody rb = newBullet.GetComponent<Rigidbody>();
		rb.AddForce(transform.forward * bulletSpeed);
		PlaySE(shootSE);
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

