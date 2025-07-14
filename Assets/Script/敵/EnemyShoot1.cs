using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyShoot1 : MonoBehaviour
{
	[SerializeField] GameObject player;
	[SerializeField] GameObject bullet;
	[SerializeField] private float fireRate; // ”­ËŠÔŠui•bj
	[SerializeField] private float nextFireTime; // Ÿ‚É”­Ë‚Å‚«‚éŠÔ
	[SerializeField] private float bulletSpeed;
	private float time = 1.0f;

	void Update()
	{
		transform.LookAt(player.transform);
		time -= Time.deltaTime;
		if (Time.time >= nextFireTime)
		{
			BallShoot();
			nextFireTime = Time.time + 1f / fireRate;
		}
	}

	void BallShoot()
	{
		//’e‚ğ¶¬
		GameObject newbullet = Instantiate(bullet, transform.position, Quaternion.identity);
		newbullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
		// ’e‚É—Í‚ğ‰Á‚¦‚é
		Rigidbody bulletRigidbod = newbullet.GetComponent<Rigidbody>();
		// ’e‘¬‚Í©—R‚Éİ’è
		bulletRigidbod.AddForce(transform.forward * bulletSpeed);
		Destroy(newbullet, 3); //3•bŒã‚É’e‚ğÁ‚·


	}
}
