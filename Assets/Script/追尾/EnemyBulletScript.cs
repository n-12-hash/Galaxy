using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EnemyBulletScript : MonoBehaviour
{
	[SerializeField] GameObject player;
	[SerializeField] GameObject bullet;
	[SerializeField] private float fireRate; // ”­ËŠÔŠui•bj
	[SerializeField] private float nextFireTime; // Ÿ‚É”­Ë‚Å‚«‚éŠÔ
	[SerializeField] private float bulletSpeed;
	private float time = 1.0f;
	public Transform Target;
	//public Transform initialposition;//random;
	NavMeshAgent agent;
	bool sensor;


	// Start is called before the first frame update
	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
	}

	// Update is called once per frame
	void Update()
	{

		if (Pause.isPaused) return; // ƒ|[ƒY’†‚Í‰½‚à‚µ‚È‚¢
		if (sensor == true)
		{
			transform.LookAt(player.transform);
			time -= Time.deltaTime;
			if (Time.time >= nextFireTime)
			{
				BallShoot();
				nextFireTime = Time.time + 1f / fireRate;
			}
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
		//3•bŒã‚É’e‚ğÁ‚·
		Destroy(newbullet, 3);
	}

	public void Syageki()
	{
		sensor = true;
	}

	public void Stop()
	{
		sensor = false;
	}

}

