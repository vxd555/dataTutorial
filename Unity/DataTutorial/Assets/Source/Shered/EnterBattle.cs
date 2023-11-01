using DG.Tweening;
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
	[SerializeField] private float enterTime = 1f;

	private void Start()
	{
		hero.DOMove(heroPosition.position, enterTime).SetEase(Ease.InExpo);
		enemy.DOMove(enemyPosition.position, enterTime).SetEase(Ease.InExpo).OnComplete(ShowUI);
	}

	private void Update()
	{
	}

	public void ShowUI()
	{
		battleUI.SetActive(true);
	}

}