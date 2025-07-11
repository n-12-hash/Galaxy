using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Text���g�����߂ɕK�v
using UnityEngine.Windows;
// �� Random �� Unity �� Random ���ƒ�`����
using Random = UnityEngine.Random;

public class Move : MonoBehaviour
{

	private Rigidbody rb;
	private Transform tf;
	// �A�j���[�V����
	private Animator animator;
	// ���E�ړ�
	private float horizontal = 0;
	private float vertical = 0;
	private Vector3 velocity;
	//[Header("�ړ����x"), SerializeField]
	private float moveSpeed = 10f;
	private float DashSpeed = 100f;
	public float jumpPower;
	bool isGround = false;      //�n�ʐڒn�t���O��錾
	int jumpCount = 0;     //�W�����v�̉񐔂��J�E���g����ϐ���錾
	Vector3 prevPos;
	int afterglowTime;

	public Vector3 Value
	{
		get => transform.position - prevPos;
	}

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
		//if (Pause.isPaused) return; // �|�[�Y���͉������Ȃ�
		//if (animator.SetBool("Start_Anim", true).isPaused) return; // �|�[�Y���͉������Ȃ�
		prevPos = transform.position;

		horizontal = UnityEngine.Input.GetAxis("Horizontal");
		velocity = new Vector3(0, 0, horizontal).normalized;
		/*
		rb.velocity =
			Vector3.Scale(rb.velocity, new Vector3(0, 1, 0)) +
			Vector3.Scale(velocity * moveSpeed, new Vector3(1, 0, 1));
		*/
		if (velocity.magnitude > 0.1f)
		{
			animator.SetBool("Walk_Anim", true);
			float moveZ = UnityEngine.Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; // ���������̈ړ�
			transform.position += new Vector3(0, 0, moveZ); // �I�u�W�F�N�g�̈ʒu���X�V
		}
		else if (horizontal < -0.1f)
		{
			animator.SetBool("Walk_Anim", true);
			float moveZ = UnityEngine.Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; // ���������̈ړ�
			transform.position += new Vector3(0, 0, moveZ); // �I�u�W�F�N�g�̈ʒu���X�V
		}

		else if (UnityEngine.Input.GetKeyDown(KeyCode.JoystickButton1))
		{
			animator.SetBool("Roll_Anim", true);
			float moveZ = UnityEngine.Input.GetAxis("Horizontal") * DashSpeed * Time.deltaTime; // ���������̈ړ�
			transform.position += new Vector3(0, 0, moveZ); // �I�u�W�F�N�g�̈ʒu���X�V
		}

		else
		{
			animator.SetBool("Walk_Anim", false);
			animator.SetBool("Roll_Anim", false);
		}


		if (velocity != Vector3.zero)
		{
			tf.rotation = Quaternion.LookRotation(velocity);
		}




		if (UnityEngine.Input.GetKey(KeyCode.JoystickButton2))
		{
			animator.SetBool("Open_Anim", false);
		}

		else
		{
			animator.SetBool("Open_Anim", true);
		}


		if (UnityEngine.Input.GetKeyDown(KeyCode.JoystickButton3) && jumpCount <= 2 )   
		{
			//Rigidbody�ɏ������JumpPower�̗͂�����
			rb.AddForce(transform.up * jumpPower);
			jumpCount++;    //jumpCount ���C���N�������g
		}
	}

	private void FixedUpdate()
	{

		afterglowTime--;
		if (GameObject.Find("Player") && - 15 > gameObject.transform.position.y)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}


	}

	//�����蔻��
	void OnCollisionEnter(Collision collision)
	{
		//������������̖��O���uPlane�v�Ȃ�
		if (collision.gameObject.tag == "Plane")
		{
			jumpCount = 0;
		}
	}

	//�E�o����
	void OnCollisionExit(Collision collision)
	{
		//�E�o��������̖��O���uPlane�v�Ȃ�
		if (collision.gameObject.tag == "Plane")
		{
			isGround = false;     //isGround�@�� false ��
		}
	}
}
