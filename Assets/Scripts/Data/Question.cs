using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : ScriptableObject
{
    [SerializeField]
    public string m_QuestionText;

    [SerializeReference]
    public List<PersonalityTrait> m_UnlockedTraits;
}
