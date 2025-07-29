using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SceneController : MonoBehaviour
{
	public static string sceneName;

	// �u���̃��\�b�h�����s���ꂽ���ɊJ���Ă���V�[���̖��O�v���擾����B
	// ����̏ꍇ�́A�Q�[���I�[�o�[�̏��������������ɁA���̃��\�b�h���Ăяo���B
	public static void CurrentSceneName()
	{
		sceneName = SceneManager.GetActiveScene().name;
		Debug.Log(sceneName);
	}

	// ��L�̃��\�b�h�Ŏ擾���ꂽ�V�[���ɖ߂�B
	// ����̏ꍇ�́A�R���e�B�j���[�{�^�������������ɂ��̃��\�b�h�����s����B
	public static void BackToBeforeScene()
	{
		SceneManager.LoadScene(sceneName);
	}
}