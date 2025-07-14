using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyShoot : MonoBehaviour
{
	[SerializeField] GameObject bullet;
	[SerializeField] private float fireRate; // 発射間隔（秒）
	[SerializeField] private float nextFireTime; // 次に発射できる時間
	[SerializeField] private float bulletSpeed;
	private float time = 1.0f;
	public float distance; // スライドする長さ
	public float length; // 反応する距離
	Vector3 startPos; // 初期位置座標
	Transform player; // プレイヤー座標


	// Use this for initialization
	void Start()
	{
		player = GameObject.Find("Player").transform; // Playerという名前のオブジェクトを取得
		startPos = transform.position; // 初期位置を代入
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 pos = transform.position; // 現在の座標

		// プレイヤーが一定の距離に近づいたら
		if (Vector3.Distance(player.position, startPos) <= length)
		{
			transform.LookAt(player.transform);
			time -= Time.deltaTime;
			if (Time.time >= nextFireTime)
			{
				BallShoot();
				nextFireTime = Time.time + 1f / fireRate;
			}
		}
		else
		{

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
			Destroy(newbullet, 3); //3秒後に弾を消す
		}

		transform.position = pos; // 座標を指定
	}
}
