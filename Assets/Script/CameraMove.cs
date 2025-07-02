using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Textを使うために必要
using TMPro;

public class CameraMove : MonoBehaviour
{
	[Header("移動速度"), SerializeField]
	public float moveSpeed = 30f;
	// アニメーション
	private Animator animator;
	// Start is called before the first frame update
	void Start()
    {

	}

    // Update is called once per frame
    void Update()
    {

		//if (Pause.isPaused) return; // ポーズ中は何もしない
		float moveZ = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; // 水平方向の移動
		//float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;   // 垂直方向の移動

		transform.position += new Vector3(0, 0, moveZ); // オブジェクトの位置を更新


	}
}
