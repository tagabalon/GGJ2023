using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalPanel : MonoBehaviour
{
    public PeopleList m_NPCs;
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
        gameObject.SetActive(true);
    }

    public void CloseJournal()
    {
        gameObject.SetActive(false);
    }
}
