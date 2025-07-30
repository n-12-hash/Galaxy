using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCon : MonoBehaviour
{
	Animator animator;
	// Start is called before the first frame update
	void Start()
	{
		//Animator�̎擾
		animator = this.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{

	}
	void OnTriggerEnter(Collider other)
	{
		//Playter��Collider�͈͓̔��ɓ�������
		if (other.tag == "Player")
		{
			//character_nearby��true�ɂ��ăh�A���J����
			animator.SetBool("character_nearby", true);
		}
	}
	void OnTriggerExit(Collider other)
	{
		//Playter��Collider�͈̔͂���o����
		if (other.tag == "Player")
		{
			//character_nearby��true�ɂ��ăh�A��߂�
			animator.SetBool("character_nearby", false);
		}
	}
}