using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Retire : MonoBehaviour
{
	[SerializeField] private GameObject pauseUI;
	public static bool isPaused = false; // �� static �ɕύX
	[SerializeField] private GameObject optionFirst;


	void OnTriggerEnter(Collider other)
	{

		if (other.tag == "Player")
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
	}

	void Awake()
	{
		isPaused = false; // �V�[���J�n���ɏ�Ƀ|�[�Y����
	}


}