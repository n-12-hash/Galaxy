using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class HpReducePlayer : MonoBehaviour
{
	SphereCollider Muteki;
	[SerializeField] GameObject explosionPrefab;
	[SerializeField] private AudioClip DamageSE;
	[SerializeField] private AudioClip SE;
	public AudioSource audioSource;
	[SerializeField] private int maxHp;
	[SerializeField] private int hp;
	[SerializeField] private GameObject HPUI;
	private Slider hpSlider;
	public Image fadePanel;
	public float fadeDuration;

	private bool isInvincible = false;
	private Animator animator;
	Renderer[] renderers;

	void Start()
	{
		animator = GetComponent<Animator>();
		renderers = GetComponentsInChildren<Renderer>();
		hp = maxHp;
		hpSlider = HPUI.transform.Find("HPBar").GetComponent<Slider>();
		hpSlider.value = 1f;
		fadePanel.enabled = false;
		var c = fadePanel.color; c.a = 0f; fadePanel.color = c;
	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "EnemyBullet" && !isInvincible)
		{
			// É_ÉÅÅ[ÉWèàóù
			hp -= 10;
			hpSlider.value = hp / (float)maxHp;
			PlaySE(DamageSE);
			Destroy(col.gameObject);
			StartCoroutine(DamageBlink());
			StartCoroutine(InvincibilityCoroutine());
		}

		if (hp <= 0)
		{
			PlaySE(SE);
			Instantiate(explosionPrefab, transform.position, Quaternion.identity);
			StartCoroutine(FadeOutAndLoadScene());
		}
	}

	private void PlaySE(AudioClip clip)
	{
		if (audioSource != null && clip != null) audioSource.PlayOneShot(clip);
	}

	private IEnumerator InvincibilityCoroutine()
	{
		isInvincible = true;
		yield return new WaitForSeconds(2f);
		isInvincible = false;
	}

	public IEnumerator DamageBlink()
	{
		float blinkInterval = 0.1f;
		int blinkCount = 10;
		for (int i = 0; i < blinkCount * 2; i++)
		{
			foreach (var r in renderers) r.enabled = !r.enabled;
			yield return new WaitForSeconds(blinkInterval);
		}
	}

	public IEnumerator FadeOutAndLoadScene()
	{
		fadePanel.enabled = true;
		float elapsed = 0f;
		Color startC = fadePanel.color;
		Color endC = new(startC.r, startC.g, startC.b, 1f);
		while (elapsed < fadeDuration)
		{
			elapsed += Time.deltaTime;
			float t = Mathf.Clamp01(elapsed / fadeDuration);
			fadePanel.color = Color.Lerp(startC, endC, t);
			yield return null;
		}
		SceneController.CurrentSceneName();
		SceneManager.LoadScene("GameOver");
	}
}
