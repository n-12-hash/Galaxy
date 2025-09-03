using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HpReduce1 : MonoBehaviour
{

	//”š”­‚ÌPrefab‚ğéŒ¾
	[SerializeField] GameObject explosionPrefab;
	[SerializeField] private AudioClip SE;
	public AudioSource audioSource;

	//[SerializeField] AudioClip se;
	//@“G‚ÌMaxHP
	[SerializeField]
	private int maxHp;
	//@“G‚ÌHP
	[SerializeField]
	private int hp;

	public void SetHp(int hp)
	{
		Debug.Log("2");
		this.hp = hp;
	}
	void OnTriggerEnter(Collider Collision)
	{
		if (Collision.gameObject.tag == "Bullet")
		{
			hp -= 10;
			Destroy(Collision.gameObject);
		}

		if (hp <= 0)
		{
			Debug.Log("1");
			GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
			var expAudio = explosion.AddComponent<AudioSource>();
			expAudio.PlayOneShot(SE);
			// explosion ‚É AutoDestroy ƒXƒNƒŠƒvƒg‚ğ•t‚¯‚Ä”•bŒã‚É”jŠü
			Destroy(gameObject); // “G‚Í‚ ‚Æ‚©‚ç”jŠü

		}

	}

	public void PlaySE(AudioClip clip)
	{
		if (audioSource != null && audioSource.enabled && audioSource.gameObject.activeInHierarchy && clip != null)
		{
			audioSource.PlayOneShot(clip);
		}
	}


}
