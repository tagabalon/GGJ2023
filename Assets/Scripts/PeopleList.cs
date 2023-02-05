using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PeopleList : MonoBehaviour
{
    public FamilyTreePanel m_FamilyTree;
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

            TextMeshProUGUI personName = personSlots[i].GetComponentInChildren<TextMeshProUGUI>();
            int j = startingDisplayIndex + i;

            if (j < unlockedNPCS.Length)
            {
                personSlots[i].SetNPC(unlockedNPCS[j], OnDisplayTooltip, OnDroppedPortrait);
            }
            else
            {
                personSlots[i].HidePortrait();
            }
        }
    }

	private bool OnDroppedPortrait(DraggablePortrait portrait)
	{
		if(m_FamilyTree.HasHightlightedSlot())
		{
            m_FamilyTree.DropPortrait(portrait);
            return true;
		}
        return false;
	}

	private void OnDisplayTooltip(Progression.UnlockedNPC npc, bool show, Vector2 position)
	{
		if(show)
		{
            m_Tooltip.Show(npc, position);
		}
		else
		{
            m_Tooltip.Hide();
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
