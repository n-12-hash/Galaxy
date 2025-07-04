using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monster : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		transform.position += transform.forward * 0.01f;
	}


	private void FixedUpdate()
	{


		if (0 > gameObject.transform.position.y && gameObject.tag == "Monster")
		{

			Destroy(this.gameObject);

		}

	}

}