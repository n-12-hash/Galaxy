using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Text���g�����߂ɕK�v
using TMPro;

public class CameraMove : MonoBehaviour
{
	private GameObject player;   //�v���C���[���i�[�p
	private Vector3 offset;      //���΋����擾�p
	int afterglowTime;

	// Use this for initialization
	void Start()
	{

		//�v���C���[�̏����擾
		this.player = GameObject.Find("robotSphere");

		// MainCamera(�������g)��player�Ƃ̑��΋��������߂�
		//offset = transform.position - player.transform.position;

	}

	// Update is called once per frame
	void Update()
	{
		transform.position += player.GetComponent<Move>().Value;

		//�V�����g�����X�t�H�[���̒l��������
		//transform.position = player.transform.position + offset;

		//�v���C���[�̌����Ɠ����悤�ɃJ�����̌�����ύX����
		//transform.rotation = player.transform.rotation;
	}


}
