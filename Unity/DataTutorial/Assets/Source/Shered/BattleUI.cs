using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
	[SerializeField] private Image heroBar;
	[SerializeField] private Image enemyBar;

	public void SetBar(float percentage, bool hero)
	{
		if(hero)
			heroBar.fillAmount = percentage;
		else
			enemyBar.fillAmount = percentage;
	}
}