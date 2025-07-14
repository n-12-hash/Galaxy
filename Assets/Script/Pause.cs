using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{
	[SerializeField] private GameObject pauseUI;
	public static bool isPaused = false; // �� static �ɕύX

	[SerializeField] private GameObject first;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Pause"))
		{
			TogglePause();
		}
	}

	public void TogglePause()
	{
		isPaused = !isPaused;
		pauseUI.SetActive(isPaused);

		if (isPaused)
		{
			StartCoroutine(SelectFirstAfterFrame());
		}
	}

	private IEnumerator SelectFirstAfterFrame()
	{
		EventSystem.current.SetSelectedGameObject(null);
		yield return null; // 1�t���[���҂�
		EventSystem.current.SetSelectedGameObject(first);
	}


	public void ResumeGame()
	{
		isPaused = false;
		pauseUI.SetActive(false);
	}
	void Awake()
	{
		isPaused = false; // �V�[���J�n���ɏ�Ƀ|�[�Y����
	}

}