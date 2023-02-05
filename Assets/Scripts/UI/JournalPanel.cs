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

        m_NPCs.DisplayPeople();
        m_FamilyTree.ShowFamilyTree();
        gameObject.SetActive(true);
    }

    public void CloseJournal()
    {
        gameObject.SetActive(false);
    }
}
