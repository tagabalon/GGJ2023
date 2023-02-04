using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PersonalityTrait : ScriptableObject
{
	[SerializeField]
	private int m_Id;

	[SerializeField]
	private string m_TraitName;

	[SerializeReference]
	List<string> m_PositiveResponses;

	[SerializeReference]
	List<string> m_NegativeResponses;
}
