using UnityEngine;

[CreateAssetMenu(menuName = "OnionMilk/Etap3/State")]
public class State_Etap3 : ScriptableObject
{
	public string id;
	public int health;
	public int damage;
	public int protection;
	public Classification3 classification;
	public Sprite sprite;
}

public enum Classification3
{
	hero = 0,
	monster = 1
}