using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AncestorObject : MonoBehaviour
{
    public Ancestor m_Data;

    private Interaction.InteractionType m_CurrentInteraction;

    private int m_EndIndex = -1;
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
            GameManager.GetInstance().UnlockNPC(m_Data);
        }
        else
        {
            newInteraction = Interaction.InteractionType.TalkAgain;
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

        if (newInteraction == Interaction.InteractionType.None)
        {
            List<string> questions = new List<string>(GameManager.GetInstance().GetInventoryQuestions());

            m_EndIndex = questions.Count;

            questions.Add("End conversation");
            SetQuestions(questions.ToArray());
        }
        else { 
            SetInteraction(newInteraction);
        }

    }

    private void SetQuestions(string[] questions)
    {
        DialogueWindow.GetInstance().ShowChoices(questions, OnQuestionSelected);
    }

    private void OnQuestionSelected(int index)
    {
        if(index == m_EndIndex)
        {
            DialogueWindow.GetInstance().Close();
        }
        else
        {
            Question selectedQuestion = GameManager.GetInstance().GetQuestion(index, true);
            if(m_Data.ProcessQuestion(selectedQuestion, out string response, out PersonalityTrait trait))
            {
                m_CurrentInteraction = Interaction.InteractionType.AnsweringQuestion;
                DialogueWindow.GetInstance().ShowText(
                    m_Data.m_CharacterName,
                    response,
                    m_Data.m_Portrait,
                    OnTextEnd);

                if(trait != null)
                {
                    UIPanel.GetInstance().ShowGab(m_Data.m_CharacterName + " is " + trait.TraitName);
                }

                GameManager.GetInstance().UnlockNPC(m_Data, trait);
            }
        }
    }

    private void SetInteraction(Interaction.InteractionType newInteraction)
    {
        m_CurrentInteraction = newInteraction;
        DialogueWindow.GetInstance().ShowText(
            m_Data.m_CharacterName,
            m_Data.GetInteractionText(m_CurrentInteraction),
            m_Data.m_Portrait,
            OnTextEnd);
    }
}
