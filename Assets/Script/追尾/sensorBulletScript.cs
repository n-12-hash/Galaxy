using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorBulletScript : MonoBehaviour
{
	public GameObject ShootPoint;
	EnemyBulletScript encs;

	// Start is called before the first frame update
	void Start()
	{
		encs = ShootPoint.GetComponent<EnemyBulletScript>();
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			encs.Syageki();
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			encs.Stop();
		}
	}
}
