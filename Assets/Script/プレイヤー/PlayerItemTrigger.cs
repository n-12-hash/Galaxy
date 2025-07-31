using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemTrigger : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Collectible"))
		{
			CollectibleManager.Instance.Collect(other.gameObject);
		}
	}
}

