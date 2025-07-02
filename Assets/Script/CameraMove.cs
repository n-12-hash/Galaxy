using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Text���g�����߂ɕK�v
using TMPro;

public class CameraMove : MonoBehaviour
{
	[Header("�ړ����x"), SerializeField]
	public float moveSpeed = 30f;
	// �A�j���[�V����
	private Animator animator;
	// Start is called before the first frame update
	void Start()
    {

	}

    // Update is called once per frame
    void Update()
    {

		//if (Pause.isPaused) return; // �|�[�Y���͉������Ȃ�
		float moveZ = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; // ���������̈ړ�
		//float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;   // ���������̈ړ�

		transform.position += new Vector3(0, 0, moveZ); // �I�u�W�F�N�g�̈ʒu���X�V


	}
}
