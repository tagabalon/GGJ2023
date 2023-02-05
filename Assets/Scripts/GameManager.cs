using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

[RequireComponent(typeof(Progression))]
public class GameManager : MonoBehaviour
{
    private static GameManager m_Instance;
    [SerializeField] GameObject panel;
    bool bookIsOpen = false;

    private void Awake()
    {
        m_Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
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

    internal void UnlockNPC(Ancestor npc, PersonalityTrait trait = null)
    {
        GetComponent<Progression>().UnlockNPC(npc, trait);
    }
    public Progression.UnlockedNPC[] GetUnlockedNPCs()
    {
        return GetComponent<Progression>().GetUnlockedNPCs();
    }

    public void OnBookClick()
    {
        if (bookIsOpen == false)
        {
            panel.SetActive(true);
            bookIsOpen = true;
        }
        else if (bookIsOpen == true)
        {
            panel.SetActive(false);
            bookIsOpen = false;
        }
    }

    internal Progression.InventoryQuestion[] GetQuestions()
    {
        return GetComponent<Progression>().GetQuestions();
    }

    internal void AddQuestion(Question question, int amount)
    {
        GetComponent<Progression>().AddQuestion(question, amount);
    }

}
