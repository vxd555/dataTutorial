using UnityEngine;

[CreateAssetMenu(menuName = "OnionMilk/Data/State")]
public class Stats : ScriptableObject
{
	public Entry this[int idx] => entries[idx];

	[SerializeField] private Entry[] entries;

	[System.Serializable]
	public class Entry : TabRow
	{
		public string id;
		public string min;
		public string max;
	}
}
