using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PeopleList : MonoBehaviour
{
    Progression.UnlockedNPC[] unlockedNPCS;
    [SerializeField] DisplayTraits[] personSlots;
    int startingDisplayIndex = 0;

    public NPCTooltip m_Tooltip;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    public void DisplayPeople()
    {

        unlockedNPCS = GameManager.GetInstance().GetUnlockedNPCs();

        for (int i = 0; i < personSlots.Length; i++)
        {
            personSlots[i].displayTraitHover = OnHover;
            personSlots[i].hideTrait = OnHoverEnd;

            TextMeshProUGUI personName = personSlots[i].GetComponentInChildren<TextMeshProUGUI>();
            int j = startingDisplayIndex + i;

            if (j < unlockedNPCS.Length)
            {
                personSlots[i].SetNPC(unlockedNPCS[j]);
            }
            else
            {
                personSlots[i].gameObject.SetActive(false);
            }
        }
    }

    private void OnHoverEnd(DisplayTraits displayTraits)
    {
        //m_Tooltip.Show(displayTraits.m_NPC);
    }

    private void OnHover(DisplayTraits displayTraits)
    {
        //m_Tooltip.Show(displayTraits.m_NPC);
    }

    public void OnUpButtonPressed()
    {
        if (startingDisplayIndex > 0)
            startingDisplayIndex -= 2;

    }

    public void OnDownButtonPressed()
    {
        //if (startingDisplayIndex < people.Count - personSlots.Length + 1)
        //    startingDisplayIndex += 2;
    }
}
