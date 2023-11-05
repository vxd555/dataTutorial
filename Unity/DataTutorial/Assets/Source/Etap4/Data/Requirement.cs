using UnityEngine;

[CreateAssetMenu(menuName = "OnionMilk/Data/Requirement")]
public class Requirement : ScriptableObject
{
	public Entry this[int idx] => entries[idx];

	[SerializeField] private Entry[] entries;

	[System.Serializable]
	public class Entry : TabRow
	{
		public string id;
		public string stats;
		public string summary;
	}
}
