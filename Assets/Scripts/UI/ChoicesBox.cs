using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoicesBox : MonoBehaviour
{
    public delegate void ChoiceHighlightCallback(ChoiceItem choice);
    public delegate void ChoiceSelectCallback(ChoiceItem choice);

    public List<ChoiceItem> m_Choices;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	internal void ShowChoices(string[] choices)
	{
        for(int i = 0; i < choices.Length; i++)
        {
            if (i >= m_Choices.Count)
            { 
                ChoiceItem newItem = Instantiate<ChoiceItem>(m_Choices[0]);
                newItem.transform.parent = m_Choices[0].transform.parent;
                newItem.transform.localScale = Vector3.one;
                m_Choices.Add(newItem);
            }
            m_Choices[i].Initialize(choices[i], OnHighlightChoice, OnSelectChoice);
        }
	}

	private void OnSelectChoice(ChoiceItem choice)
	{
		
	}

	private void OnHighlightChoice(ChoiceItem choice)
	{
		
	}
}
