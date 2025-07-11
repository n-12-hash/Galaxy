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


	void Start()
	{

	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.JoystickButton4) || Input.GetKeyDown(KeyCode.JoystickButton5) )
		{
			// ”­Ë‰¹‚ğo‚·
			AudioSource.PlayClipAtPoint(sound, transform.position);
			//’e‚ğ¶¬
			GameObject newbullet = Instantiate(PistolBullet, this.transform.position, Quaternion.identity);//’e‚ğ¶¬
			Rigidbody bulletRigidbody = newbullet.GetComponent<Rigidbody>();
			bulletRigidbody.AddForce(this.transform.forward * bulletSpeed); //ƒLƒƒƒ‰ƒNƒ^[‚ªŒü‚¢‚Ä‚¢‚é•ûŒü‚É’e‚É—Í‚ğ‰Á‚¦‚é	
			Destroy(newbullet, 3); //3•bŒã‚É’e‚ğÁ‚·

		}

	}

}
