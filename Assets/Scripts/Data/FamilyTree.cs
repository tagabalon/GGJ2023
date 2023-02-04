using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

[System.Serializable]
public class FamilyTree : ScriptableObject
{
    [System.Serializable]
    public class FamilyMember
    {
        [SerializeReference]
        public Ancestor m_Child;

        [SerializeReference]
        public Ancestor m_Father;

        [SerializeReference]
        public Ancestor m_Mother;
    }

	[SerializeReference]
    public List<FamilyMember> m_Members;
}
