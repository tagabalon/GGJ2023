using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
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

        internal void UnlockTraits(PersonalityTrait trait)
        {
            if(m_UnlockedTraits == null)
                m_UnlockedTraits = new List<PersonalityTrait>();

            if(!m_UnlockedTraits.Contains(trait))
            {
                m_UnlockedTraits.Add(trait);
            }
        }
        internal PersonalityTrait[] GetTraits()
        {
            return m_UnlockedTraits.ToArray();
        }
    }

    [System.Serializable]
    public class InventoryQuestion
    {
        public Question m_Question;
        public int m_Count;
    }

    public List<UnlockedNPC> m_UnlockedNPCs = new List<UnlockedNPC>();
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

    internal void UnlockNPC(Ancestor npc, PersonalityTrait trait)
    {
        bool found = false;
        foreach (UnlockedNPC unlockedNPC in m_UnlockedNPCs)
        {
            if (unlockedNPC.m_NPC == npc)
            {
                unlockedNPC.UnlockTraits(trait);
                found = true;
                break;
            }
        }
        if(!found)
        {
            UnlockedNPC unlockedNPC = new UnlockedNPC();
            unlockedNPC.m_NPC = npc;
            unlockedNPC.UnlockTraits(trait);
            m_UnlockedNPCs.Add(unlockedNPC);
        }
    }

    public UnlockedNPC[] GetUnlockedNPCs()
    {
        return m_UnlockedNPCs.ToArray();
    }

    internal InventoryQuestion[] GetQuestions()
    {
        return m_Questions.ToArray();
    }

    internal void AddQuestion(Question question, int amount)
    {
        InventoryQuestion q = GetInventoryQuestion(question);
        if(q == null)
        {
            q = new InventoryQuestion();
            q.m_Question = question;
            q.m_Count = 1;

            m_Questions.Add(q);
        }
        else
        {
            q.m_Count += amount;
        }
    }

    private InventoryQuestion GetInventoryQuestion(Question question)
    {
        foreach(InventoryQuestion q in m_Questions) { 
            if(q.m_Question = question)
            {
                return q;
            }
        }
        return null;
    }
}
