using UnityEngine;

[CreateAssetMenu(menuName = "OnionMilk/Data/Slot")]
public class Slot : ScriptableObject
{
	public Entry this[int idx] => entries[idx];

	[SerializeField] private Entry[] entries;

	[System.Serializable]
	public class Entry : TabRow
	{
		public string id;
		public string type;
		public string category;
		public bool wearable;
		public int count;
	}
}
