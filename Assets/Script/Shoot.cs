using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{

	public AudioClip sound;
	public GameObject PistolBullet; // ’e
	public float fireRate = 2.0f;   // ”­ËŠÔŠu
	public float bulletSpeed; //’e‚Ì‘¬“x
	[SerializeField] private float nextFireTime; // Ÿ‚É”­Ë‚Å‚«‚éŠÔ


	void Update()
	{
		if (Input.GetKeyDown(KeyCode.JoystickButton4) || Input.GetKeyDown(KeyCode.JoystickButton5) )
		{
			PlayerShoot();
			nextFireTime = Time.time + 1f / fireRate;
		}

	}

	void PlayerShoot()
	{
		// ”­Ë‰¹‚ğo‚·
		AudioSource.PlayClipAtPoint(sound, transform.position);
		//’e‚ğ¶¬
		GameObject newbullet = Instantiate(PistolBullet, this.transform.position, Quaternion.identity);
		Rigidbody bulletRigidbody = newbullet.GetComponent<Rigidbody>();
		//ƒLƒƒƒ‰ƒNƒ^[‚ªŒü‚¢‚Ä‚¢‚é•ûŒü‚É’e‚É—Í‚ğ‰Á‚¦‚é	
		bulletRigidbody.AddForce(this.transform.forward * bulletSpeed);
		//3•bŒã‚É’e‚ğÁ‚·
		Destroy(newbullet, 3);
	}

}
