using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyShoot : MonoBehaviour
{
	[SerializeField] private AudioClip shootSE;
	public AudioSource audioSource;
	public GameObject shellPrefab; // 弾
	[SerializeField] private float bulletSpeed;
	[SerializeField] private float fireRate; // 発射間隔（秒）
	[SerializeField] private float nextFireTime; // 次に発射できる時間

	/*void Start()
	{
		// 指定したメソッドを、指定した時間（単位；秒）から、指定した間隔（単位；秒）で繰り返し実行する。
		InvokeRepeating("Shot", 0f, 1f);
	}*/

	void Update()
	{
		if (Time.time >= nextFireTime)
		{
			Shoot();
			nextFireTime = Time.time + 1f / fireRate;
		}
	}

	void Shoot()
	{
		// 弾を生成
		GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);
		// 弾に力を加える
		Rigidbody shellRb = shell.GetComponent<Rigidbody>();
		// 弾速は自由に設定
		shellRb.AddForce(transform.forward * bulletSpeed);

		// 発射音を出す
		PlaySE(shootSE);

		// ５秒後に砲弾を破壊する
		Destroy(shell, 5.0f);
	}
	private void PlaySE(AudioClip clip)
	{
		if (audioSource != null && clip != null)
		{
			audioSource.PlayOneShot(clip);
		}
	}
}


