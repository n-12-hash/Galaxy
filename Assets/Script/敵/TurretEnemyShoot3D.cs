using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemyShoot3D : MonoBehaviour
{
	public GameObject shellPrefab; // ’e‚ÌƒvƒŒƒnƒu
	public float fireRate = 1f; // ”­ËŠÔŠui•bj
	public float shellSpeed = 5f; // ’e‚Ì‘¬“x
	public Transform bulletPosition; // ’e‚Ì”­ËˆÊ’u

	private float nextFireTime = 0f;

	void Update()
	{
		// ˆê’èŠÔ‚²‚Æ‚É’e‚ğ”­Ë
		if (Time.time >= nextFireTime)
		{
			Shoot();
			nextFireTime = Time.time + fireRate;
		}
	}

	void Shoot()
	{
		// ’e‚ğ¶¬
		GameObject shell = Instantiate(shellPrefab, bulletPosition.position, Quaternion.identity);
		// ’e‚É—Í‚ğ‰Á‚¦‚Ä‘O•û‚Ö”­Ë
		Rigidbody rb = shell.GetComponent<Rigidbody>();
		if (rb != null)
		{
			rb.velocity = transform.forward * shellSpeed; // “G‚ÌŒü‚«‚É‘¬“x‚ğİ’è
		}
	}
}


