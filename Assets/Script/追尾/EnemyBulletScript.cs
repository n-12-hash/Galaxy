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
	[SerializeField] private float fireRate; // 発射間隔（秒）
	[SerializeField] private float nextFireTime; // 次に発射できる時間
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

		if (Pause.isPaused) return; // ポーズ中は何もしない
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
		//弾を生成
		GameObject newbullet = Instantiate(bullet, transform.position, Quaternion.identity);
		newbullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
		// 弾に力を加える
		Rigidbody bulletRigidbod = newbullet.GetComponent<Rigidbody>();
		// 弾速は自由に設定
		bulletRigidbod.AddForce(transform.forward * bulletSpeed);
		//3秒後に弾を消す
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

