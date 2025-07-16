using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{

	private Animator animator;  // アニメーション
	public AudioClip sound;
	public GameObject PistolBullet; // 弾
	public float fireRate = 2.0f;   // 発射間隔
	public float bulletSpeed; //弾の速度
	[SerializeField] private float nextFireTime; // 次に発射できる時間
	Move script; //参照するスクリプト


	void Update()
	{
		if (/*animator.SetBool("Walk_Anim", true) &&*/ Input.GetKeyDown(KeyCode.JoystickButton4) || Input.GetKeyDown(KeyCode.JoystickButton5))
		{
			PlayerShoot();
			nextFireTime = Time.time + 1f / fireRate;
		}

	}

	void PlayerShoot()
	{
		// 発射音を出す
		AudioSource.PlayClipAtPoint(sound, transform.position);
		//弾を生成
		GameObject newbullet = Instantiate(PistolBullet, this.transform.position, Quaternion.identity);
		Rigidbody bulletRigidbody = newbullet.GetComponent<Rigidbody>();
		//キャラクターが向いている方向に弾に力を加える	
		bulletRigidbody.AddForce(this.transform.forward * bulletSpeed);
		//3秒後に弾を消す
		Destroy(newbullet, 3);
	}

}
