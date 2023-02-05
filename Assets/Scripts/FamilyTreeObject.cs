using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class FamilyTreeObject : MonoBehaviour
{
	[System.Serializable]
    public class AnswerData
	{
		[SerializeField]
        public FamilyTreeItem m_Item;

        [SerializeField]
        public Ancestor m_NPC;

        internal bool IsCorrect()
        {
            bool isCorrect = true;

            if(m_Item.GetDraggablePortrait() != null)
            {
                if (m_Item.GetDraggablePortrait().m_NPC.m_NPC != this.m_NPC)
                    isCorrect = false;

            }
            else
            {
                isCorrect = false;
            }

            return isCorrect;
        }
    }
     
    public List<AnswerData> m_AnswerList;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    internal AnswerData[] GetTreeItems()
    {
        return m_AnswerList.ToArray();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
