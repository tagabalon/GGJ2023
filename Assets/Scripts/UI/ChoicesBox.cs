using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoicesBox : MonoBehaviour
{
    public delegate void OnChoiceSelect(int index);

    private OnChoiceSelect m_OnChoiceSelect;
    public List<ChoiceItem> m_Choices;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	internal void ShowChoices(string[] choices, OnChoiceSelect onChoiceSelected)
	{
        m_OnChoiceSelect = onChoiceSelected;
        for (int i = 0; i < choices.Length; i++)
        {
            if (i >= m_Choices.Count)
            { 
                ChoiceItem newItem = Instantiate<ChoiceItem>(m_Choices[0]);
                newItem.transform.SetParent(m_Choices[0].transform.parent);
                m_Choices.Add(newItem);
            }
            m_Choices[i].Initialize(choices[i], OnSelectChoice);
        }
        for(int i = choices.Length; i < m_Choices.Count; i++)
        {
            m_Choices[i].gameObject.SetActive(false);
        }
	}

	private void OnSelectChoice(ChoiceItem choice)
	{
        m_OnChoiceSelect?.Invoke(m_Choices.IndexOf(choice));

    }
}
