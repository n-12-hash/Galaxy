using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Textを使うために必要
using TMPro;

public class CameraMove : MonoBehaviour
{
	private GameObject player;   //プレイヤー情報格納用
	private Vector3 offset;      //相対距離取得用
	int afterglowTime;

	// Use this for initialization
	void Start()
	{

		//プレイヤーの情報を取得
		this.player = GameObject.Find("robotSphere");

		// MainCamera(自分自身)とplayerとの相対距離を求める
		//offset = transform.position - player.transform.position;

	}

	// Update is called once per frame
	void Update()
	{
		transform.position += player.GetComponent<Move>().Value;

		//新しいトランスフォームの値を代入する
		//transform.position = player.transform.position + offset;

		//プレイヤーの向きと同じようにカメラの向きを変更する
		//transform.rotation = player.transform.rotation;
	}


}
