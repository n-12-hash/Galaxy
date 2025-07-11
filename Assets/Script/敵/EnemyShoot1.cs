using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot1 : MonoBehaviour
{
	[SerializeField] GameObject player;
	[SerializeField] GameObject bullet;
	[SerializeField] private float bulletSpeed;
	private float time = 1.0f;

	void Update()
	{
		transform.LookAt(player.transform);
		time -= Time.deltaTime;
		if (time <= 0)
		{
			BallShot();
			time = 1.0f;
		}
	}

	void BallShot()
	{
		GameObject newbullet = Instantiate(bullet, transform.position, Quaternion.identity);//’e‚ğ¶¬
		newbullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
		Rigidbody bulletRigidbody = newbullet.GetComponent<Rigidbody>();
		bulletRigidbody.AddForce(transform.forward * bulletSpeed); //ƒLƒƒƒ‰ƒNƒ^[‚ªŒü‚¢‚Ä‚¢‚é•ûŒü‚É’e‚É—Í‚ğ‰Á‚¦‚é*/
		Destroy(newbullet, 3); //3•bŒã‚É’e‚ğÁ‚·


	}
}
