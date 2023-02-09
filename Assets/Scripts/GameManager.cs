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
    [SerializeField] FamilyTreeObject familyTreeObject;
    [SerializeField] GameObject winScreen;
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

    public void OnBookSubmit()
    {

        bool isCorrect = true;

        FamilyTreeObject.AnswerData[] correctAnswers = familyTreeObject.GetTreeItems();


        for(int i = 0; i < correctAnswers.Length; i++)
        {
            if (!correctAnswers[i].IsCorrect())
                isCorrect = false;
        }


        if (isCorrect)
        {
            UIPanel.GetInstance().ShowWinPanel();
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
