using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Etap1_Stats : BattleSystem
{
	[Header("Bindings")]
	[SerializeField] protected Transform hero;
	[SerializeField] protected Transform enemy;
	[SerializeField] protected Button attack = null;

	[Header("Stats")]
	public int enemyHealthMax;
	public int enemyHealth;
	public int enemyDamage;
	public int heroHealthMax;
	public int heroHealth;
	public int heroDamage;


	public void Start()
	{
		Init();
	}

	public override void Init()
	{
		enemyHealth = enemyHealthMax;
		heroHealth = heroHealthMax;

		attack.onClick.AddListener(AttackHero);
	}

	public override void DealDamageFromHero()
	{
		base.DealDamageFromHero();

		enemyHealth -= heroDamage;
		if(enemyHealth <= 0)
		{
			enemyHealth = 0;
			Win();
		}
		battleUI.SetBar((float)enemyHealth / (float)enemyHealthMax, false);
	}

	public override void DealDamageFromEnemy()
	{
		base.DealDamageFromEnemy();

		heroHealth -= enemyDamage;
		if(heroHealth <= 0)
		{
			heroHealth = 0;
			Lose();
		}
		battleUI.SetBar((float)heroHealth / (float)heroHealthMax, true);
	}

	public virtual void AttackHero()
	{
		attack.gameObject.SetActive(false);

		Sequence sequence = DOTween.Sequence();

		sequence.Append(hero.DOMove(hero.position + new Vector3(-2f, 0f, 0f), 1f));
		sequence.Append(hero.DOMove(hero.position, 0.3f).OnComplete(AttackEnemy));
		sequence.Play();
	}

	public virtual void AttackEnemy()
	{
		DealDamageFromHero();
		if(enemyHealth == 0)
			return;

		Sequence sequence = DOTween.Sequence();

		sequence.Append(enemy.DOMove(enemy.position + new Vector3(2f, 0f, 0f), 1f));
		sequence.Append(enemy.DOMove(enemy.position, 0.3f).OnComplete(FinishTurn));
		sequence.Play();
	}

	protected virtual void FinishTurn()
	{
		DealDamageFromEnemy();
		if(heroHealth == 0)
			return;

		attack.gameObject.SetActive(true);

	}
}
