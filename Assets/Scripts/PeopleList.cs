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

    // Start is called before the first frame update
    void Start()
    {
        unlockedNPCS = GameManager.GetInstance().GetUnlockedNPCs();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    void DisplayPeople()
    {
        for(int i = 0; i < personSlots.Length; i++)
        {
            personSlots[i].displayTraitHover = OnHover;
            Sprite personImage = personSlots[i].GetComponentInChildren<Sprite>();
            TextMeshProUGUI personName = personSlots[i].GetComponentInChildren<TextMeshProUGUI>();
            int j = startingDisplayIndex + i;

            if (j < unlockedNPCS.Length)
            {
                personImage =  unlockedNPCS[j].m_NPC.m_Portrait;
                personName.text = unlockedNPCS[j].m_NPC.m_CharacterName;

                GameObject namesText = personSlots[j].dialoguePanel.transform.Find("Names Text").gameObject;
                GameObject traitsText = personSlots[j].dialoguePanel.transform.Find("Traits Text").gameObject;

                namesText.GetComponent<TextMeshProUGUI>().text = personName.text;

                List<PersonalityTrait> traitList = unlockedNPCS[j].m_UnlockedTraits;

                for(int k = 0; k < traitList.Count; k++)
                    traitsText.GetComponent<TextMeshProUGUI>().text += traitList[k].TraitName + "\n";

            }
            else
            {
                personImage = null;
                personName.text = null;
            }
        }
    }

    private void OnHover(DisplayTraits displayTraits)
    {
        
    }

    public void OnUpButtonPressed()
    {
        if (startingDisplayIndex > 0)
            startingDisplayIndex -= 2;

    }

    public void OnDownButtonPressed()
    {
        if (startingDisplayIndex < people.Count - personSlots.Length + 1)
            startingDisplayIndex += 2;
    }
}
