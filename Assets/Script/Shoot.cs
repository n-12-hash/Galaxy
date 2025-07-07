using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{


	public GameObject PistolBullet; // ’e
	public float fireRate = 0.5f;   // ”­ËŠÔŠu
	public float bulletSpeed; //’e‚Ì‘¬“x


	void Start()
	{

	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.JoystickButton4) || Input.GetKeyDown(KeyCode.JoystickButton5) )
		{
			//’e‚ğ¶¬
			GameObject Bullet = Instantiate(PistolBullet, this.transform.position, Quaternion.identity);//’e‚ğ¶¬
			Rigidbody bulletRigidbody = PistolBullet.GetComponent<Rigidbody>();
			bulletRigidbody.AddForce(this.transform.forward * bulletSpeed); //ƒLƒƒƒ‰ƒNƒ^[‚ªŒü‚¢‚Ä‚¢‚é•ûŒü‚É’e‚É—Í‚ğ‰Á‚¦‚é	
			Destroy(Bullet, 3); //3•bŒã‚É’e‚ğÁ‚·

		}

	}

}
