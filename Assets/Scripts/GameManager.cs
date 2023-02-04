using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

[RequireComponent(typeof(Progression))]
public class GameManager : MonoBehaviour
{
    private static GameManager m_Instance;

    private void Awake()
    {
        m_Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static GameManager GetInstance()
    {
        return m_Instance;
    }

    internal bool IsNPCUnlocked(Ancestor npcData)
    {
        return GetComponent<Progression>().IsNPCUnlocked(npcData);
    }

    internal string[] GetInventoryQuestions()
    {
        return GetComponent<Progression>().GetInventoryQuestions();
    }

    internal Question GetQuestion(int index, bool removeFromInventory)
    {
        return GetComponent<Progression>().GetQuestion(index, removeFromInventory);
    }
}
