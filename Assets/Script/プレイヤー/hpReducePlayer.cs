using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HpReducePlayer: MonoBehaviour
{
	//������Prefab��錾
	[SerializeField] GameObject explosionPrefab;
	[SerializeField] AudioClip se;
	//�@������MaxHP
	[SerializeField]
	private int maxHp;
	//�@������HP
	[SerializeField]
	private int hp;
	//�@HP�\���pUI
	[SerializeField]
	private GameObject HPUI;
	//�@HP�\���p�X���C�_�[
	private Slider hpSlider;
	// �t�F�[�h
	public Image fadePanel;      // �t�F�[�h�p��UI�p�l���iImage�j
	public float fadeDuration;   // �t�F�[�h�̊����ɂ����鎞��

	private void Start()
	{
		hp = maxHp;
		hpSlider = HPUI.transform.Find("HPBar").GetComponent<Slider>();
		hpSlider.value = 1f;

		fadePanel.enabled = false;
		Color c = fadePanel.color;
		c.a = 0f;
		fadePanel.color = c;
	}


	public void SetHp(int hp)
	{
		this.hp = hp;
	}
	void OnTriggerExit(Collider Collision)
	{
		if (Collision.gameObject.gameObject.tag == "EnemyBullet"){
			hp -= 10;
			hpSlider.value = hp / (float)maxHp;
			Debug.Log("��������" + hpSlider.value);
			Destroy(Collision.gameObject);
		}

		if (hp == 0)
		{
			AudioSource.PlayClipAtPoint(se, transform.position);//����������
			GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
			Destroy(explosion, 2.0f); //2�b��ɔ������폜
			StartCoroutine(FadeOutAndLoadScene());
		}
	}

	public IEnumerator FadeOutAndLoadScene()
	{
		fadePanel.enabled = true;                 // �p�l����L����
		float elapsedTime = 0.0f;                 // �o�ߎ��Ԃ�������
		Color startColor = fadePanel.color;       // �t�F�[�h�p�l���̊J�n�F���擾
		Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f); // �t�F�[�h�p�l���̍ŏI�F��ݒ�

		// �t�F�[�h�A�E�g�A�j���[�V���������s
		while (elapsedTime < fadeDuration)
		{
			elapsedTime += Time.deltaTime;                        // �o�ߎ��Ԃ𑝂₷
			float t = Mathf.Clamp01(elapsedTime / fadeDuration);  // �t�F�[�h�̐i�s�x���v�Z
			fadePanel.color = Color.Lerp(startColor, endColor, t); // �p�l���̐F��ύX���ăt�F�[�h�A�E�g
			yield return null;                                     // 1�t���[���ҋ@
		}

		fadePanel.color = endColor;  // �t�F�[�h������������ŏI�F�ɐݒ�
		SceneManager.LoadScene("GameOver");
	}
}
