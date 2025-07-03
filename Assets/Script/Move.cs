using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ★ Random は Unity の Random だと定義する
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Textを使うために必要
using TMPro;
using UnityEngine.Windows;

public class Move : MonoBehaviour
{
	/*public string leftkey;      // 左キー
	public string rightkey;     // 右キー
	public string jumpkey;      // ジャンプキー	
	public string shootkey;     // 銃キー
	public string Dashkey;      // ダッシュキー	*/

	private Rigidbody rb;
	private Transform tf;
	// アニメーション
	private Animator animator;
	// 左右移動
	private float horizontal = 0;
	private float vertical = 0;
	private Vector3 velocity;
	[Header("移動速度"), SerializeField]
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
		// if (Pause.isPaused) return; // ポーズ中は何もしない
		//float moveZ = UnityEngine.Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; // 水平方向の移動
		//transform.position += new Vector3(0, 0, moveZ); // オブジェクトの位置を更新

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
