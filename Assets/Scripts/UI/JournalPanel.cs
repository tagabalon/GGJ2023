using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static FamilyTreeObject;

public class JournalPanel : MonoBehaviour
{
    public PeopleList m_NPCs;
    public FamilyTreePanel m_FamilyTree;

    [SerializeField] Button submitButtton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    internal void OpenJournal()
    {
        foreach (AnswerData answer in m_FamilyTree.m_Tree.GetTreeItems())
        {
            if (answer.m_Item.GetDraggablePortrait() == null)
            {
                this.submitButtton.interactable = false;
            }
        }


        m_NPCs.DisplayPeople();
        m_FamilyTree.ShowFamilyTree();
        gameObject.SetActive(true);
    }

    public void CloseJournal()
    {
        gameObject.SetActive(false);
    }
}
