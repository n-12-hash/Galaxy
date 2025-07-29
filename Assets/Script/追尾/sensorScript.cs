using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorScript : MonoBehaviour
{
	public GameObject enemy;
	EnemyScript encs;
	// Start is called before the first frame update
	void Start()
	{
		encs = enemy.GetComponent<EnemyScript>();
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			encs.Tuiseki();
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			encs.Haikai();
		}
	}
}
