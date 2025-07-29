using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditorInternal.ReorderableList;

public class Shoot : MonoBehaviour
{

	private Animator animator;  // アニメーション
	[SerializeField] private AudioClip shootSE;
	public AudioSource audioSource;
	public GameObject PistolBullet; // 弾
	public float bulletSpeed; //弾の速度
	private float fireRate = 0.5f;   // 発射間隔
	private float nextFireTime = 5.0f; // 次に発射できる時間
	Move script; //参照するスクリプト

	/*private void Start()
	{
		if (volumeSlider != null)
		{
			volumeSlider.onValueChanged.AddListener((value) =>
			{
				// valueは0～1の値を期待する。それを保証するための処理
				value = Mathf.Clamp01(value);

				float decibel = 20f * Mathf.Log10(value);
				decibel = Mathf.Clamp(decibel, -80f, 0f);
				audioMixer.SetFloat(audioSource, decibel);
			});
		}
	}*/

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

		if (Pause.isPaused) return; // ポーズ中は何もしない

		//弾を生成
		GameObject newbullet = Instantiate(PistolBullet, this.transform.position, Quaternion.identity);
		Rigidbody bulletRigidbody = newbullet.GetComponent<Rigidbody>();
		//キャラクターが向いている方向に弾に力を加える	
		bulletRigidbody.AddForce(this.transform.forward * bulletSpeed);
		// 発射音を出す
		PlaySE(shootSE);
		//3秒後に弾を消す
		Destroy(newbullet, 3);
	}

	private void PlaySE(AudioClip clip)
	{
		if (audioSource != null && clip != null)
		{
			audioSource.PlayOneShot(clip);
		}
	}
}
