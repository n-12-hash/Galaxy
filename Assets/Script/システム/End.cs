using UnityEngine;

public class End : MonoBehaviour
{
	public void EndGame()
	{


#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false; // エディタの再生停止
#else
        Application.Quit(); // 実機終了
#endif
	}
}
