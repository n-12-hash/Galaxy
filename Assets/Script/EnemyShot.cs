using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
	[SerializeField] GameObject player;
	[SerializeField] GameObject bullet;
	private float ballSpeed = 10.0f;
	private float time = 1.0f;

	void Update()
	{
		transform.LookAt(player.transform);
		time -= Time.deltaTime;
		if (time <= 0)
		{
			BallShot();
			time = 5.0f;
		}
	}

	void BallShot()
	{
		GameObject shotObj = Instantiate(bullet, transform.position, Quaternion.identity);
		shotObj.GetComponent<Rigidbody>().velocity = transform.forward * ballSpeed;
		Destroy(gameObject, 3); //3ïbå„Ç…íeÇè¡Ç∑
	}
}
