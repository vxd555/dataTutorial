using UnityEngine;

[CreateAssetMenu(menuName = "OnionMilk/Data/Item")]
public class Item : ScriptableObject
{
	string id;
	string type;
	string category;
	string state;
	string use;
	string requirementWear;
	string requirementHave;
}
