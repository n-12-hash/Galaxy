using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{

		void OnTriggerEnter(Collider collision)
		{
				Destroy(collision.gameObject); //�Փ˂������������
		}
}
