using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EnemyScript : MonoBehaviour
{
	public Transform Target;
	public Transform initialposition;//random;
	NavMeshAgent agent;
	bool sensor;
	public float speed;

	// Start is called before the first frame update
	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
	}

	// Update is called once per frame
	void Update()
	{

		if (Pause.isPaused) return; // ポーズ中は何もしない
		if (sensor == false)
		{
			//agent.destination = initialposition.transform.position;
		}
		else
		{
			agent.destination = Target.transform.position;
		}
	}

	public void Tuiseki()
	{
		sensor = true;
	}

	public void Haikai()
	{
		sensor = false;
	}

}

