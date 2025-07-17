using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Homing : MonoBehaviour
{
	public GameObject target;
	private NavMeshAgent agent;

	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
	}

	void Update()
	{

		if (Pause.isPaused) return; // �|�[�Y���͉������Ȃ�
		if (target)
		{
			agent.destination = target.transform.position;
		}
	}
}
