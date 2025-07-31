using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemTrigger : MonoBehaviour
{

	[SerializeField] private AudioClip SE;
	public AudioSource audioSource;
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Collectible"))
		{
			CollectibleManager.Instance.Collect(other.gameObject);
			PlaySE(SE);
		}
	}


	private void PlaySE(AudioClip clip)
	{
		if (audioSource != null && clip != null)
		{
			audioSource.PlayOneShot(clip);
		}
	}
}

