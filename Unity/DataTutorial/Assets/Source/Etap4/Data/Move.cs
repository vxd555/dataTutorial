using UnityEngine;

[CreateAssetMenu(menuName = "OnionMilk/Data/Move")]
public class Move : ScriptableObject
{
	public Entry this[int idx] => entries[idx];

	[SerializeField] private Entry[] entries;

	[System.Serializable]
	public class Entry : TabRow
	{
		public string id;
		public string cost;
		public string attack;
	}
}

