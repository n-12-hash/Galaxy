using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
	//Audio�~�L�T�[������Ƃ��ł�
	[SerializeField] AudioMixer audioMixer;

	//���ꂼ��̃X���C�_�[������Ƃ��ł��B
	//�����ꍇ�͔z��ɂ��Ă������ł��ˁB
	[SerializeField] Slider BGMSlider;
	[SerializeField] Slider SESlider;

	private void Start()
	{
		//�~�L�T�[��volume�ɃX���C�_�[��volume�����Ă܂��B

		//BGM
		audioMixer.GetFloat("BGM", out float bgmVolume);
		BGMSlider.value = bgmVolume;
		//SE
		audioMixer.GetFloat("SE", out float seVolume);
		SESlider.value = seVolume;
	}

	//�X���C�_�[�Ŏg�������ł��B
	public void SetBGM(float volume)
	{
		audioMixer.SetFloat("BGM", volume);
	}

	public void SetSE(float volume)
	{
		audioMixer.SetFloat("SE", volume);
		//�����Ŋm�F�p�̉���炵�Ă��ǂ������B
	}
}
