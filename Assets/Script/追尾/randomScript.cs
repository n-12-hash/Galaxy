using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomScript : MonoBehaviour
{
	void Start()
	{
		StartCoroutine(Warp());
	}

	private IEnumerator Warp()
	{
		while (true)
		{
			// 10�b�ゲ�ƂɃ��[�v�ړ�����B
			yield return new WaitForSeconds(10f);

			// �����_���Ȓl���擾����B
			float posX = Random.Range(-120, 120);
			float posZ = Random.Range(-200, 200);

			transform.position = new Vector3(posX, 0, posZ);
		}
	}
}

