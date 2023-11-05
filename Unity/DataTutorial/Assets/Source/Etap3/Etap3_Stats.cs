using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Etap3_Stats : Etap1_Stats
{
	[Header("Bindings")]
	[SerializeField] protected SpriteRenderer monsterImage;
	[SerializeField] protected SpriteRenderer heroImage;

	[Header("Stats")]
	public int enemyProtection;
	public int heroProtection;

	public ProtectionType protectionType;

	public void Start()
	{
		Init();
	}

	public override void Init()
	{
		State_Etap3 monster = CharacterDB_Etap3.me.GetRandomCharacter(Classification3.monster);
		State_Etap3 hero = CharacterDB_Etap3.me.GetCharacter("hero_01");

		enemyHealthMax = monster.health;
		enemyHealth = monster.health;
		enemyDamage = monster.damage;
		enemyProtection = monster.protection;
		monsterImage.sprite = monster.sprite;

		heroHealthMax = hero.health;
		heroHealth = hero.health;
		heroDamage = hero.damage;
		heroProtection = hero.protection;
		heroImage.sprite = hero.sprite;

		attack.onClick.AddListener(AttackHero);
	}

	public override void DealDamageFromHero()
	{
		if(protectionType == ProtectionType.reduceAttack)
			ReduceHeroAttack();
		else if(protectionType == ProtectionType.reduceAttack)
			ReduceToOneHeroAttack();
		else if(protectionType == ProtectionType.skipAttack)
			SkipHeroAttack();

		if(enemyHealth <= 0)
		{
			enemyHealth = 0;
			Win();
		}
		battleUI.SetBar((float)enemyHealth / (float)enemyHealthMax, false);
	}

	public override void DealDamageFromEnemy()
	{
		if(protectionType == ProtectionType.reduceAttack)
			ReduceEnemyAttack();
		else if(protectionType == ProtectionType.reduceAttack)
			ReduceToOneEnemyAttack();
		else if(protectionType == ProtectionType.skipAttack)
			SkipEnemyAttack();

		if(heroHealth <= 0)
		{
			heroHealth = 0;
			Lose();
		}
		battleUI.SetBar((float)heroHealth / (float)heroHealthMax, true);
	}


	//hero
	private void SkipHeroAttack()
	{
		if(enemyProtection > 0)
		{
			--enemyProtection;
			return;
		}
		enemyHealth -= heroDamage;
	}

	private void ReduceToOneHeroAttack()
	{
		enemyHealth -= Mathf.Max(heroDamage - enemyProtection, 1);
	}

	private void ReduceHeroAttack()
	{
		enemyHealth -= Mathf.Max(heroDamage - enemyProtection, 0);
	}

	//enemy
	private void SkipEnemyAttack()
	{
		if(heroProtection > 0)
		{
			--heroProtection;
			return;
		}
		heroHealth -= enemyDamage;
	}

	private void ReduceToOneEnemyAttack()
	{
		heroHealth -= Mathf.Max(enemyDamage - heroProtection, 1);
	}

	private void ReduceEnemyAttack()
	{
		heroHealth -= Mathf.Max(enemyDamage - heroProtection, 0);
	}
}

public enum ProtectionType
{
	reduceAttack = 0,
	reduceAttackToOne = 1,
	skipAttack = 2
}