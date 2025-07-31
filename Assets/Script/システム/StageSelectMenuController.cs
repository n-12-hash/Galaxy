using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StageSelectMenuController : MonoBehaviour
{

	[SerializeField] private Button stage1;
	[SerializeField] private Button stage2;
	[SerializeField] private Button stage3;
	[SerializeField] private Button stage4;
	[SerializeField] private Button stage5;

	private bool isProcessing = false;

	private void Start()
	{
		// スタートボタンのクリックイベントに登録
		stage1.onClick.AddListener(OnStartButtonClicked);
		stage2.onClick.AddListener(OnStartButtonClicked);
		stage3.onClick.AddListener(OnStartButtonClicked);
		stage4.onClick.AddListener(OnStartButtonClicked);
		stage5.onClick.AddListener(OnStartButtonClicked);
	}

	private void OnStartButtonClicked()
	{
		if (isProcessing) return;  // 連打防止

		isProcessing = true;

		// 他のボタンを無効化
		stage1.interactable = false; 
		stage2.interactable = false; 
		stage3.interactable = false; 
		stage4.interactable = false; 
		stage5.interactable = false; 


		// ここにスタート処理（フェード開始やシーン遷移など）を入れる
		Debug.Log("スタートが押されました");

		// 例: フェード処理開始など
	}
}

