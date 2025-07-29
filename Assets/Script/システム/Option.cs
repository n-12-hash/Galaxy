using UnityEngine.EventSystems;
using UnityEngine;

public class Option : MonoBehaviour
{
	[SerializeField] private GameObject pauseUI;
	public static bool isPaused = false; // ← static に変更
	[SerializeField] private GameObject menuFirst;
	[SerializeField] private GameObject optionFirst;

	void Update()
	{
		if (Input.GetButtonDown("Pause"))
		{

			TogglePause();
		}
	}

	public void TogglePause()
	{
		isPaused = !isPaused;
		if (isPaused)
		{
			EventSystem.current.SetSelectedGameObject(null);
			EventSystem.current.SetSelectedGameObject(optionFirst);
		}
		pauseUI.SetActive(isPaused);

	}

	public void ResumeGame()
	{
		isPaused = false;
		pauseUI.SetActive(false);
		EventSystem.current.SetSelectedGameObject(null);
		EventSystem.current.SetSelectedGameObject(menuFirst);
	}

	void Awake()
	{
		isPaused = false; // シーン開始時に常にポーズ解除
	}

}