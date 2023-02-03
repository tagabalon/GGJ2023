using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextBox : MonoBehaviour
{

    public TMP_Text m_CharacterName;
    public TMP_Text m_Dialogue;

    private int m_TextSize = 0;
    private bool m_TextDisplaying = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_TextDisplaying)
		{
            m_Dialogue.maxVisibleCharacters++;
            if(m_Dialogue.maxVisibleCharacters >= m_TextSize)
			{
                m_TextDisplaying = false;
			}

        }
    }

	internal void ShowText(string characterName, string text)
	{
		m_CharacterName.text = characterName;
        m_TextSize = text.Length;
        m_Dialogue.text = text;
        m_Dialogue.maxVisibleCharacters = 0;
        m_TextDisplaying = true;

    }
}
