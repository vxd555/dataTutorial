using System.Collections.Generic;
using UnityEngine;

public class CharacterDB_Etap3 : MonoBehaviour
{
	private static CharacterDB_Etap3 characterDB = null;

	public static CharacterDB_Etap3 me => characterDB;

	[SerializeField]
	private List<State_Etap3> charactersList = new List<State_Etap3>();

	private Dictionary<string, State_Etap3> characters = new Dictionary<string, State_Etap3>();

	private void Awake()
	{
		if(characterDB == null)
			characterDB = this;

		for(int i = 0; i < charactersList.Count; ++i)
			characters.Add(charactersList[i].id, charactersList[i]);
	}

	public State_Etap3 GetRandomCharacter(Classification3 classification)
	{
		int rand = Random.Range(0, charactersList.Count);
		int index = 0;
		for(int classificationIndex = 0; classificationIndex <= rand;)
		{
			if(classification == charactersList[index].classification)
			{
				if(classificationIndex == rand)
					return charactersList[index];
				
				++classificationIndex;
			}

			++index;

			if(index == charactersList.Count)
			{
				index = 0;
				if(classificationIndex == 0)
				{
					Debug.LogError($"There is no class form {classification}");
					return null;
				}
			}
		}

		Debug.LogError("Nothing to find");
		return null;
	}

	public State_Etap3 GetCharacter(string id)
	{
		return characters[id];
	}

	public State_Etap3 GetCharacterFromList(string id)
	{
		for(int i = 0; i < charactersList.Count; ++i)
			if(charactersList[i].id == id)
				return charactersList[i];

		return null;
	}
}
