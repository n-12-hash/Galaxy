using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCon : MonoBehaviour
{
	[SerializeField] private AudioClip SE;
	[SerializeField] private AudioSource audioSource;
	Animator animator;
	// Start is called before the first frame update
	void Start()
	{
		//Animatorの取得
		animator = this.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{

	}
	void OnTriggerEnter(Collider other)
	{
		//PlayterがColliderの範囲内に入ったら
		if (other.tag == "Player")
		{
			//character_nearbyをtrueにしてドアを開ける
			animator.SetBool("character_nearby", true);
			PlaySE(SE);
		}
	}
	void OnTriggerExit(Collider other)
	{
		//PlayterがColliderの範囲から出たら
		if (other.tag == "Player")
		{
			//character_nearbyをtrueにしてドアを閉める
			animator.SetBool("character_nearby", false);
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