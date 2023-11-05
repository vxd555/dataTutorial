using UnityEngine;

[CreateAssetMenu(menuName = "OnionMilk/Data/AttackCalculation")]
public class AttackCalculation : ScriptableObject
{
	public Entry this[int idx] => entries[idx];

	[SerializeField] private Entry[] entries;

	[System.Serializable]
	public class Entry : TabRow
	{
		public string id;
		public string calculation;
	}
}
