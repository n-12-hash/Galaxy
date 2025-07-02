using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
	

	[Header("移動速度"), SerializeField]
	public float moveSpeed = 30f;

	// アニメーション
	private Animator animator;

	// Start is called before the first frame update
	void Start()
    {
		animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
		// if (Pause.isPaused) return; // ポーズ中は何もしない

		animator.SetBool("Walk_Anim", false);

		float moveZ = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; // 水平方向の移動
		transform.position += new Vector3(0, 0, moveZ); // オブジェクトの位置を更新

		//Input.GetKey();

	}
}
