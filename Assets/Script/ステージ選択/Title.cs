using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
	//�}�E�X
	public void change_button()
	{
		this.gameObject.SetActive(false);
		SceneManager.LoadScene("Title");
	}

	private void Update()
	{
		if (Mathf.Approximately(Time.timeScale, 0f))
		{
			return;
		}
	}
}
