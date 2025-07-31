using UnityEngine;

public class Shoot : MonoBehaviour
{
	[SerializeField] private AudioClip shootSE;
	public AudioSource audioSource;
	public GameObject PistolBullet; // ’e
	public float bulletSpeed = 500f; // ’e‚Ì‘¬“x

	private float fireRate = 0.2f;   // ”­ËŠÔŠui•bj
	private float nextFireTime = 0f; // Ÿ‚É”­Ë‚Å‚«‚éŠÔ

	void Update()
	{
		// ƒ{ƒ^ƒ“‚ğ‰Ÿ‚µ‘±‚¯‚Ä‚¢‚éŠÔA”­Ëˆ—‚ğŒJ‚è•Ô‚·
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
		// ’e‚ğ¶¬
		GameObject newBullet = Instantiate(PistolBullet, transform.position, Quaternion.identity);
		Rigidbody rb = newBullet.GetComponent<Rigidbody>();

		// ’e‚ğƒLƒƒƒ‰‚Ì‘O•û‚Ö”ò‚Î‚·
		rb.AddForce(transform.forward * bulletSpeed);

		// ”­Ë‰¹
		PlaySE(shootSE);

		// 3•bŒã‚É’e‚ğíœ
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
