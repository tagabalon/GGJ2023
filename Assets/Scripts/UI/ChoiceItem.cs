using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChoiceItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text m_Text;
	private ChoicesBox.ChoiceHighlightCallback m_OnHighlightChoice;
	private ChoicesBox.ChoiceSelectCallback m_OnSelectChoice;
    private EventSystem m_EventSystem;

    private float m_Scale = 1.0f;
    private bool m_Highlighted = false;

    public string Text
    {
        get
        {
            return m_Text.text;
        }
        internal set
        {
            m_Text.text = value;
        }
    }

	// Start is called before the first frame update
	void Start()
    {
        m_EventSystem = FindObjectOfType<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (m_Highlighted)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, 1.5f * Vector3.one, Time.deltaTime * 3.0f);
        }
		else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, Time.deltaTime * 4.0f);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        m_Highlighted = true;
        m_OnHighlightChoice(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_Highlighted = false;
    }

    internal void Initialize(string text, ChoicesBox.ChoiceHighlightCallback onHighlightChoice, ChoicesBox.ChoiceSelectCallback onSelectChoice)
	{
        m_Text.text = text;
        m_OnHighlightChoice = onHighlightChoice;
        m_OnSelectChoice = onSelectChoice;
	}

}
