using UnityEngine;

[CreateAssetMenu(menuName = "OnionMilk/Data/Merchant")]
public class Merchant : ScriptableObject
{
	public Entry this[int idx] => entries[idx];

	[SerializeField] private Entry[] entries;

	[System.Serializable]
	public class Entry : TabRow
	{
		public string id;
		public string item;
	}
}
