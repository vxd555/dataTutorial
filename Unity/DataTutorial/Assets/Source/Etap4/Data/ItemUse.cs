using UnityEngine;

[CreateAssetMenu(menuName = "OnionMilk/Data/ItemUse")]
public class ItemUse : ScriptableObject
{
	public Entry this[int idx] => entries[idx];

	[SerializeField] private Entry[] entries;

	[System.Serializable]
	public class Entry : TabRow
	{
		public string id;
	}
}
