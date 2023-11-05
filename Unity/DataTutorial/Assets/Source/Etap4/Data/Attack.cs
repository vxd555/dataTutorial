using UnityEngine;

[CreateAssetMenu(menuName = "OnionMilk/Data/Attack")]
public class Attack : ScriptableObject
{
	public Entry this[int idx] => entries[idx];

	[SerializeField] private Entry[] entries;

	[System.Serializable]
	public class Entry : TabRow
	{
		public string id;
		public string range;
		public string attackCalculation;
	}
}
