using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyTreeObject : MonoBehaviour
{
	[System.Serializable]
    public class AnswerData
	{
		[SerializeField]
        public FamilyTreeItem m_Item;

        [SerializeField]
        public Ancestor m_NPC;
	}

    public List<AnswerData> m_AnswerList;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    internal FamilyTreeItem[] GetTreeItems()
    {
        List<FamilyTreeItem> temp = new List<FamilyTreeItem>();
        foreach (AnswerData answer in m_AnswerList)
        {
            if (answer.m_Item != null)
			{
                temp.Add(answer.m_Item);
			}
        }
        return temp.ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
