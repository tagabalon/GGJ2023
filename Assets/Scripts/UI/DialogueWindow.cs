using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static ChoicesBox;
using static TextBox;

public class DialogueWindow : MonoBehaviour
{
    public TextBox m_TextBox;
    public ChoicesBox m_Choices;

	private void Awake()
	{
        m_Instance = this;

    }

	// Start is called before the first frame update
	void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		
    }

    public void TestDisplay()
    {
        //ShowChoices(new string[] { "Option a", "Option b" }, null);
        //ShowText("Obi wan", "Hello there, this is a test message", null);
    }

    public void ShowText(string characterName, string text, Sprite bust, OnTextContinue onTextContinue)
	{
        m_TextBox.ShowText(characterName, text, bust, onTextContinue);
        GetComponent<Animator>().SetBool("ShowText", true);
    }
    public void ShowChoices(string[] choices, OnChoiceSelect onChoiceSelected)
	{
        m_OnChoiceSelected = onChoiceSelected;
        m_Choices.ShowChoices(choices, OnChoiceSelected);
        GetComponent<Animator>().SetBool("ShowChoice", true);
	}

    private void OnChoiceSelected(int index)
    {
        GetComponent<Animator>().SetBool("ShowChoice", false);
        m_OnChoiceSelected(index);
    }

    private static DialogueWindow m_Instance;
    private OnChoiceSelect m_OnChoiceSelected;

    public static DialogueWindow GetInstance()
	{
        return m_Instance;
	}

    public void Close()
    {
        GetComponent<Animator>().SetBool("ShowChoice", false);
        GetComponent<Animator>().SetBool("ShowText", false);
    }
}
