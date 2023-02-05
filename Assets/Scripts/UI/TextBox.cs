using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TextBox : MonoBehaviour, IPointerClickHandler
{
    public delegate void OnTextContinue();
    private OnTextContinue m_OnTextContinue;

    public TMP_Text m_CharacterName;
    public TMP_Text m_Dialogue;
    public Image m_Bust;
    public Image m_Prompter;

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
            if(Input.GetKeyUp(KeyCode.Space))
            {
                m_Dialogue.maxVisibleCharacters = m_TextSize;
            }

            if(m_Dialogue.maxVisibleCharacters >= m_TextSize)
			{
                m_TextDisplaying = false;
                m_Prompter.gameObject.SetActive(true);
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                m_OnTextContinue();
            }
        }
    }

	internal void ShowText(string characterName, string text, Sprite bust, OnTextContinue onTextContinue)
	{
		m_CharacterName.text = characterName;
        m_TextSize = text.Length;
        m_Dialogue.text = text;
        m_Dialogue.maxVisibleCharacters = 0;
        m_TextDisplaying = true;
        m_Prompter.gameObject.SetActive(false);
        if (bust != null)
        {
            m_Bust.sprite = bust;
            m_Bust.gameObject.SetActive(true);
        }
        else
        {
            m_Bust.gameObject.SetActive(false);
        }

        m_OnTextContinue = onTextContinue;

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == 0)
        {
            if (m_TextDisplaying)
            {
                m_Dialogue.maxVisibleCharacters = m_TextSize;
                m_TextDisplaying = false;
                m_Prompter.gameObject.SetActive(true);
            }
            else
            {
                m_OnTextContinue();
            }
        }
    }
}
