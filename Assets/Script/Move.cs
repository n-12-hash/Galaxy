using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// �� Random �� Unity �� Random ���ƒ�`����
using Random = UnityEngine.Random;
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

	private Rigidbody rb;
	private Transform tf;
	// �A�j���[�V����
	private Animator animator;
	// ���E�ړ�
	private float horizontal = 0;
	private float vertical = 0;
	private Vector3 velocity;
	[Header("�ړ����x"), SerializeField]
	public float moveSpeed = 30f;



	// Start is called before the first frame update
	void Start()
    {
		rb = GetComponent<Rigidbody>();
		tf = GetComponent<Transform>();
		animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
		// if (Pause.isPaused) return; // �|�[�Y���͉������Ȃ�
		//float moveZ = UnityEngine.Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; // ���������̈ړ�
		//transform.position += new Vector3(0, 0, moveZ); // �I�u�W�F�N�g�̈ʒu���X�V

		horizontal = UnityEngine.Input.GetAxis("Horizontal");
		velocity = new Vector3(0, 0, horizontal).normalized;
		rb.velocity = velocity * moveSpeed;
		if (horizontal == 0)
		{			
			animator.SetBool("Walk_Anim", false);

		}
		else if (horizontal > 0.1f) 
		{
			animator.SetBool("Walk_Anim", true);
		}
		else 
		{
			animator.SetBool("Walk_Anim", true);
		}


		if (velocity != Vector3.zero)
		{
			tf.rotation = Quaternion.LookRotation(velocity);
		}
			//Input.GetKey();

	}
}
