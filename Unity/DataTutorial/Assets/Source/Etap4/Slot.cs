using UnityEngine;

[CreateAssetMenu(menuName = "OnionMilk/Data/Slot")]
public class Slot : ScriptableObject
{
	string id;
	string type;
	string category;
	bool wearable;
	int count;
}
