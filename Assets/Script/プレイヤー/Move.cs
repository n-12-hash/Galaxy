using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Text���g�����߂ɕK�v
using UnityEngine.InputSystem;
using UnityEngine.Windows;
// �� Random �� Unity �� Random ���ƒ�`����
using Random = UnityEngine.Random;

public class Move : MonoBehaviour
{
	[SerializeField] GameObject jumpPrefab; // �W�����v�G�t�F�N�g
	private Rigidbody rb;
	private Transform tf;
	// �A�j���[�V����
	private Animator animator;
	// SE
	[SerializeField] private AudioClip SE;
	public AudioSource audioSource;
	// ���E�ړ�
	private float horizontal = 0;
	private float vertical = 0;
	private Vector3 velocity;
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

		if (Pause.isPaused) return; // �|�[�Y���͉������Ȃ�
		//if (animator.SetBool("Start_Anim", true).isPaused) return; // �|�[�Y���͉������Ȃ�
		/*rb.velocity =
		Vector3.Scale(rb.velocity, new Vector3(0, 1, 0)) +
		Vector3.Scale(velocity * moveSpeed, new Vector3(1, 0, 1));*/

		prevPos = transform.position;
		horizontal = UnityEngine.Input.GetAxis("Horizontal");
		velocity = new Vector3(0, 0, horizontal).normalized;

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

		else
		{
			animator.SetBool("Walk_Anim", false);
		}

		if (UnityEngine.Input.GetKeyDown(KeyCode.JoystickButton1))
		{
			animator.SetBool("Roll_Anim", true);
			float moveZ = UnityEngine.Input.GetAxis("Horizontal") * DashSpeed * Time.deltaTime; // ���������̈ړ�
			transform.position += new Vector3(0, 0, moveZ); // �I�u�W�F�N�g�̈ʒu���X�V

		}

		else
		{
			animator.SetBool("Roll_Anim", false);
		}

		if (velocity != Vector3.zero)
		{
			tf.rotation = Quaternion.LookRotation(velocity);
		}

		if (UnityEngine.Input.GetKeyDown(KeyCode.JoystickButton3) && jumpCount <= 1 )   
		{
			//Rigidbody�ɏ������JumpPower�̗͂�����
			rb.AddForce(transform.up * jumpPower);
			GameObject Jump = Instantiate(jumpPrefab, transform.position, Quaternion.identity);
			PlaySE(SE);
			Destroy(Jump, 2.0f); //2�b��ɍ폜
			jumpCount++;    //jumpCount ���C���N�������g
		}
	}

	private void PlaySE(AudioClip clip)
	{
		if (audioSource != null && clip != null)
		{
			audioSource.PlayOneShot(clip);
		}
	}

	private void FixedUpdate()
	{

		afterglowTime--;
		if (GameObject.Find("Player") && - 15 > gameObject.transform.position.y)
		{
			gameObject.transform.position = new Vector3(0, 0, 0);
		}


	}

	//�����蔻��
	void OnCollisionEnter(Collision collision)
	{
		//������������̖��O���uPlane�v�Ȃ�
		if (collision.gameObject.tag == "Plane" || collision.gameObject.tag == "Turret")
		{
			jumpCount = 0;
		}
	}

	//�E�o����
	void OnCollisionExit(Collision collision)
	{
		//�E�o��������̖��O���uPlane�v�Ȃ�
		if (collision.gameObject.tag == "Plane" || collision.gameObject.tag == "Turret")
		{
			isGround = false;     //isGround�@�� false ��
		}
	}
}
