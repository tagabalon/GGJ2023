using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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
        ShowChoices(new string[] { "Option a", "Option b" });
        ShowText("Obi wan", "Hello there, this is a test message", null);
    }

    public void ShowText(string characterName, string text, OnTextContinue onTextContinue)
	{
        m_TextBox.ShowText(characterName, text, onTextContinue);
        GetComponent<Animator>().SetBool("ShowText", true);
    }
    public void ShowChoices(string[] choices)
	{
        m_Choices.ShowChoices(choices);
        GetComponent<Animator>().SetBool("ShowChoice", true);
	}

    private static DialogueWindow m_Instance;
    public static DialogueWindow GetInstance()
	{
        return m_Instance;
	}
}
