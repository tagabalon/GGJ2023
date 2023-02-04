using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AncestorObject : MonoBehaviour
{
    public Ancestor m_Data;

    private Interaction.InteractionType m_CurrentInteraction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        Interaction.InteractionType newInteraction = Interaction.InteractionType.None;
        if (!GameManager.GetInstance().IsNPCUnlocked(m_Data))
        {
            newInteraction = Interaction.InteractionType.FirstGreeting;
        }
        if (newInteraction != Interaction.InteractionType.None)
        {
            SetInteraction(newInteraction);
        }
    }

    private void OnTextEnd()
    {
        Interaction.InteractionType newInteraction = Interaction.InteractionType.None;
        switch(m_CurrentInteraction)
        {
            case Interaction.InteractionType.FirstGreeting:
                newInteraction = Interaction.InteractionType.SelfIntro;
                break;
        }

        if(newInteraction != Interaction.InteractionType.None)
        {
            SetInteraction(newInteraction);
        }

    }

    private void SetInteraction(Interaction.InteractionType newInteraction)
    {
        m_CurrentInteraction = newInteraction;
        DialogueWindow.GetInstance().ShowText(
            m_Data.m_CharacterName,
            m_Data.GetInteractionText(m_CurrentInteraction),
            OnTextEnd);
    }
}
