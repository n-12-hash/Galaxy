using UnityEngine;

public class End : MonoBehaviour
{
	public void EndGame()
	{


#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false; // �G�f�B�^�̍Đ���~
#else
        Application.Quit(); // ���@�I��
#endif
	}
}
