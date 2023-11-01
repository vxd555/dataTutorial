using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem: MonoBehaviour
{
    [SerializeField] protected BattleUI battleUI = null;

	public virtual void Init()
	{
	}

	public virtual void DealDamageFromHero()
    {
    }

	public virtual void DealDamageFromEnemy()
	{
	}

	public virtual void Win()
	{
	}

	public virtual void Lose()
	{
	}

}
