using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        ShowText("Obi wan", "Hello there, this is a test message");
    }

    public void ShowText(string characterName, string text)
	{
        m_TextBox.ShowText(characterName, text);
    }
    public void ShowChoices(string[] choices)
	{
        m_Choices.ShowChoices(choices);
        GetComponent<Animator>().SetBool("Show", true);
	}

    private static DialogueWindow m_Instance;
    public static DialogueWindow GetInstance()
	{
        return m_Instance;
	}
}