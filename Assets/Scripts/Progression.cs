using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private List<UnlockedNPC> m_UnlockedNPCs = new List<UnlockedNPC>();


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
}
