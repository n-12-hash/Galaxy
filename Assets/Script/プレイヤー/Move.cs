using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Textを使うために必要
using UnityEngine.InputSystem;
using UnityEngine.Windows;
// ★ Random は Unity の Random だと定義する
using Random = UnityEngine.Random;

public class Move : MonoBehaviour
{
	[SerializeField] GameObject jumpPrefab; // ジャンプエフェクト
	private Rigidbody rb;
	private Transform tf;
	// アニメーション
	private Animator animator;
	// SE
	[SerializeField] private AudioClip SE;
	public AudioSource audioSource;
	// 左右移動
	private float horizontal = 0;
	private float vertical = 0;
	private Vector3 velocity;
	private float moveSpeed = 10f;
	private float DashSpeed = 100f;
	public float jumpPower;
	bool isGround = false;      //地面接地フラグを宣言
	int jumpCount = 0;     //ジャンプの回数をカウントする変数を宣言
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

		if (Pause.isPaused) return; // ポーズ中は何もしない
		//if (animator.SetBool("Start_Anim", true).isPaused) return; // ポーズ中は何もしない
		/*rb.velocity =
		Vector3.Scale(rb.velocity, new Vector3(0, 1, 0)) +
		Vector3.Scale(velocity * moveSpeed, new Vector3(1, 0, 1));*/

		prevPos = transform.position;
		horizontal = UnityEngine.Input.GetAxis("Horizontal");
		velocity = new Vector3(0, 0, horizontal).normalized;

		if (velocity.magnitude > 0.1f)
		{
			animator.SetBool("Walk_Anim", true);
			float moveZ = UnityEngine.Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; // 水平方向の移動
			transform.position += new Vector3(0, 0, moveZ); // オブジェクトの位置を更新

		}
		else if (horizontal < -0.1f)
		{
			animator.SetBool("Walk_Anim", true);
			float moveZ = UnityEngine.Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; // 水平方向の移動
			transform.position += new Vector3(0, 0, moveZ); // オブジェクトの位置を更新
		}

		else
		{
			animator.SetBool("Walk_Anim", false);
		}

		if (UnityEngine.Input.GetKeyDown(KeyCode.JoystickButton1))
		{
			animator.SetBool("Roll_Anim", true);
			float moveZ = UnityEngine.Input.GetAxis("Horizontal") * DashSpeed * Time.deltaTime; // 水平方向の移動
			transform.position += new Vector3(0, 0, moveZ); // オブジェクトの位置を更新

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
			//Rigidbodyに上方向にJumpPowerの力を加え
			rb.AddForce(transform.up * jumpPower);
			GameObject Jump = Instantiate(jumpPrefab, transform.position, Quaternion.identity);
			PlaySE(SE);
			Destroy(Jump, 2.0f); //2秒後に削除
			jumpCount++;    //jumpCount をインクリメント
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

	//当たり判定
	void OnCollisionEnter(Collision collision)
	{
		//当たった相手の名前が「Plane」なら
		if (collision.gameObject.tag == "Plane" || collision.gameObject.tag == "Turret")
		{
			jumpCount = 0;
		}
	}

	//脱出判定
	void OnCollisionExit(Collision collision)
	{
		//脱出した相手の名前が「Plane」なら
		if (collision.gameObject.tag == "Plane" || collision.gameObject.tag == "Turret")
		{
			isGround = false;     //isGround　を false に
		}
	}
}
