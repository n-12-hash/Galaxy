using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectibleManager : MonoBehaviour
{
	public static CollectibleManager Instance { get; private set; }
	private int totalItems;
	private int collected;
	public string sceneKey;

	private void Awake()
	{
		if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
		else Destroy(gameObject);
	}

	private void Start()
	{
		totalItems = GameObject.FindGameObjectsWithTag("Collectible").Length;
		collected = 0;
		sceneKey = SceneManager.GetActiveScene().name;
	}

	public void Collect(GameObject item)
	{
		collected++;
		Destroy(item);

		if (collected >= totalItems)
		{
			PlayerPrefs.SetInt($"Unlocked_{sceneKey}", 1);
			PlayerPrefs.Save();
			Debug.Log($"Stage {sceneKey} unlocked hidden content!");
		}
	}
}
