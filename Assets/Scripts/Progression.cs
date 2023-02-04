using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Progression : MonoBehaviour
{
    [System.Serializable]
    public class UnlockedNPC
    {
        public Ancestor m_NPC;
        public bool m_Locked = true;
        public List<PersonalityTrait> m_UnlockedTraits;

        internal bool IsUnlocked()
        {
            return !m_Locked;
        }
    }

    [System.Serializable]
    public class InventoryQuestion
    {
        public Question m_Question;
        public int m_Count;
    }

    private List<UnlockedNPC> m_UnlockedNPCs = new List<UnlockedNPC>();
    public List<InventoryQuestion> m_Questions;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal bool IsNPCUnlocked(Ancestor npcData)
    {
        foreach(UnlockedNPC npc in m_UnlockedNPCs){
            if(npc.m_NPC == npcData)
            {
                return npc.IsUnlocked();
            }
        }
        return false;
    }

    internal string[] GetInventoryQuestions()
    {
        List<string> temp = new List<string>();
        foreach(InventoryQuestion q in m_Questions)
        {
            temp.Add(q.m_Question.m_QuestionText);
        }
        return temp.ToArray();
    }

    internal Question GetQuestion(int index, bool removeFromInventory)
    {
        if(index < m_Questions.Count)
        {
            Question question = m_Questions[index].m_Question;
            if(removeFromInventory)
            {
                if (m_Questions[index].m_Count > 2)
                {
                    m_Questions[index].m_Count--;
                }
                else
                {
                    m_Questions.RemoveAt(index);
                }
            }
            return question;
        }
        return null;
    }
}
