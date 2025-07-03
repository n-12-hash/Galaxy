using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	[SerializeField] GameObject sphere;
	[SerializeField] GameObject childObj;
	private float speed = 300;

	void Start()
	{
		childObj = transform.GetChild(0).gameObject;
	}

	void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			GameObject ball = (GameObject)Instantiate(sphere, childObj.transform.position, Quaternion.identity);
			Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
			ballRigidbody.AddForce(transform.forward * speed);
		}

		if (Input.GetKey("right"))
		{
			transform.Rotate(0, 2, 0);
		}

		if (Input.GetKey("left"))
		{
			transform.Rotate(0, -2, 0);
		}
	}
}