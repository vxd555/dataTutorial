using UnityEngine;

[CreateAssetMenu(menuName = "OnionMilk/Data/Item")]
public class Item : ScriptableObject
{
	public Entry this[int idx] => entries[idx];

	[SerializeField] private Entry[] entries;

	[System.Serializable]
	public class Entry : TabRow
	{
		public string id;
		public string type;
		public string category;
		public string stats;
		public string use;
		public string requirementWear;
		public string requirementHave;
	}
}
