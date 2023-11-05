using UnityEngine;

[CreateAssetMenu(menuName = "OnionMilk/Data/Character")]
public class Character : ScriptableObject
{
	public Entry this[int idx] => entries[idx];

	[SerializeField] private Entry[] entries;

	[System.Serializable]
	public class Entry : TabRow
	{
		public string id;
		public string stats;
		public string slot;
		public string move;
		public string classification;
		public string ai;
	}
}
