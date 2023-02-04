using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ancestor : ScriptableObject
{
    public string m_CharacterName;

    public List<NPCResponse> m_ResponseList;

    public List<PersonalityTrait> m_TraitList;

    internal string GetInteractionText(Interaction.InteractionType interaction)
    {
        if(interaction == Interaction.InteractionType.FirstGreeting ||
            interaction == Interaction.InteractionType.SelfIntro)
        {
            foreach(NPCResponse response in m_ResponseList)
            {
                if(response.m_InteractionType == interaction)
                {
                    return response.m_Text;
                }
            }
        }
        return "Text Missing";

    }
}
