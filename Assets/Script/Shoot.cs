using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

	public float bulletSpeed; //’e‚Ì‘¬“x
	public GameObject PistolBullet; // ’e
	public float fireRate = 0.5f;   // ”­ËŠÔŠu
	private float speed = 300;


	private Collider objectCollider;
	private Rigidbody rb;

	void Start()
	{
		objectCollider = GetComponent<SphereCollider>();
		objectCollider.isTrigger = true; //Trigger‚Æ‚µ‚Äˆµ‚¤
		rb = GetComponent<Rigidbody>();
		rb.useGravity = false; //d—Í‚ğ–³Œø‚É‚·‚é
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.JoystickButton4) || Input.GetKeyDown(KeyCode.JoystickButton5) )
		{
			//’e‚ğ¶¬
			GameObject Bullet = Instantiate(PistolBullet, this.transform.position, Quaternion.identity);
			Rigidbody bulletRigidbody = PistolBullet.GetComponent<Rigidbody>();

			//3•bŒã‚É’e‚ğÁ‚·	
			Destroy(Bullet, 3);

			// ’e‚É‘¬“x‚ğ—^‚¦‚é
			Rigidbody rb = Bullet.GetComponent<Rigidbody>();
			if (rb != null)
			{
				rb.velocity = this.transform.forward * bulletSpeed;
			}

		}

	}


}
