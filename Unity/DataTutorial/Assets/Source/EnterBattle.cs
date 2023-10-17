using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBattle : MonoBehaviour
{
	[Header("Bindings")]
	[SerializeField] private Transform hero;
	[SerializeField] private Transform enemy;
	[SerializeField] private Transform heroPosition;
	[SerializeField] private Transform enemyPosition;
	[SerializeField] private GameObject battleUI;

	[Header("Settings")]
	[SerializeField] private float enterTimeFactor = 1f;

	private Vector3 heroStart;
	private Vector3 enemyStart;

	private void Start()
	{
		StartCoroutine(EnterAnimation());
	}

	private void Update()
	{
	}

	public IEnumerator EnterAnimation()
	{
		float t = 0f;

		heroStart = hero.position;
		enemyStart = enemy.position;

		while(t < 1f)
		{
			t += Time.deltaTime * enterTimeFactor;

			hero.position = Vector3.Lerp(heroStart, heroPosition.position, t);
			enemy.position = Vector3.Lerp(enemyStart, enemyPosition.position, t);

			yield return null;
		}

		yield return null;

		hero.position = heroPosition.position;
		enemy.position = enemyPosition.position;

		battleUI.SetActive(true);
	}
}