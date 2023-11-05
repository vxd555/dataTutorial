using UnityEngine;

[CreateAssetMenu(menuName = "OnionMilk/Data/Range")]
public class Range : ScriptableObject
{
	public Entry this[int idx] => entries[idx];

	[SerializeField] private Entry[] entries;

	[System.Serializable]
	public class Entry : TabRow
	{
		public string id;
	}
}
