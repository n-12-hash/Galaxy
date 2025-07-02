using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Text���g�����߂ɕK�v
using TMPro;
using UnityEngine.Windows;

public class Move : MonoBehaviour
{
	/*public string leftkey;      // ���L�[
	public string rightkey;     // �E�L�[
	public string jumpkey;      // �W�����v�L�[	
	public string shootkey;     // �e�L�[
	public string Dashkey;      // �_�b�V���L�[	*/
	

	[Header("�ړ����x"), SerializeField]
	public float moveSpeed = 30f;

	// �A�j���[�V����
	private Animator animator;

	// Start is called before the first frame update
	void Start()
    {
		animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
		// if (Pause.isPaused) return; // �|�[�Y���͉������Ȃ�

		animator.SetBool("Walk_Anim", false);

		float moveZ = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; // ���������̈ړ�
		transform.position += new Vector3(0, 0, moveZ); // �I�u�W�F�N�g�̈ʒu���X�V

		//Input.GetKey();

	}
}
