using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
	[SerializeField] private Button startButton;
	[SerializeField] private Button leftArrowButton;
	[SerializeField] private Button resetButton;

	private bool isProcessing = false;

	private void Start()
	{
		// スタートボタンのクリックイベントに登録
		startButton.onClick.AddListener(OnStartButtonClicked);
	}

	private void OnStartButtonClicked()
	{
		if (isProcessing) return;  // 連打防止

		isProcessing = true;

		// 他のボタンを無効化
		startButton.interactable = false; ;
		leftArrowButton.interactable = false;
		resetButton.interactable = false;

		// ここにスタート処理（フェード開始やシーン遷移など）を入れる
		Debug.Log("スタートが押されました");

		// 例: フェード処理開始など
	}
}

