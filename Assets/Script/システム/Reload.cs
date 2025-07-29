using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour
{
	void Update()
	{
		LoadScene();
	}
	// Update is called once per frame
	public void LoadScene()
	{
		SceneManager.LoadScene("Stage1");
	}
}
