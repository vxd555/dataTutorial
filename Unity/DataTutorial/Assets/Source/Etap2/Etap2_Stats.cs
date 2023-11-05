using System.Collections.Generic;
using UnityEngine;

public class Etap2_Stats : Etap1_Stats
{
	[Header("Bindings")]
	[SerializeField] protected SpriteRenderer monsterImage;

	[Header("Monsters")]
	[SerializeField] private List<MonsterStats> monsterStats = new List<MonsterStats>();

	public void Start()
	{
		Init();
	}

	public override void Init()
	{
		int monsterID = Random.Range(0, monsterStats.Count);

		enemyHealthMax = monsterStats[monsterID].health;
		enemyHealth = monsterStats[monsterID].health;
		enemyDamage = monsterStats[monsterID].damage;
		monsterImage.sprite = monsterStats[monsterID].sprite;

		heroHealth = heroHealthMax;

		attack.onClick.AddListener(AttackHero);
	}


	[System.Serializable]
	public class MonsterStats
	{
		public int health;
		public int damage;
		public Sprite sprite;
	}
}
