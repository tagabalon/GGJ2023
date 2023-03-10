using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ancestor : ScriptableObject
{
    public string m_CharacterName;
    public Sprite m_Portrait;
    public Ancestor m_Father;
    public Ancestor m_Mother;

    public List<NPCResponse> m_ResponseList;

    public List<PersonalityTrait> m_TraitList;

    internal string GetInteractionText(Interaction.InteractionType interaction)
    {
        if(interaction == Interaction.InteractionType.FirstGreeting ||
            interaction == Interaction.InteractionType.SelfIntro
            || interaction == Interaction.InteractionType.TalkAgain)
        {
            foreach(NPCResponse response in m_ResponseList)
            {
                if(response.m_InteractionType == interaction)
                {
                    return response.m_Text;
                }
            }
        }
        return "Text Missing for interaction type " + interaction;

    }

    internal bool ProcessQuestion(Question question, out string npcResponse, out PersonalityTrait trait)
    {
        List<string> responses = new List<string>();
        List<PersonalityTrait> traits = new List<PersonalityTrait>();
        foreach(PersonalityTrait unlockedTrait in question.m_UnlockedTraits)
        {
            if(m_TraitList.Contains(unlockedTrait))
            {
                responses.AddRange(unlockedTrait.GetPositiveResponses());
                traits.Add(unlockedTrait);
            }
            else
            {
                responses.AddRange(unlockedTrait.GetNegativeResponses());
            }
        }
        npcResponse = "";
        trait = null;
        if(responses.Count > 0)
        {
            npcResponse = responses[0];
            if(traits.Count > 0)
            {
                trait = traits[0];
            }
            return true;
        }
        return false;
    }
}
