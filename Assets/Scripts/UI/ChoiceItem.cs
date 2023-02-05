using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChoiceItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public delegate void ChoiceSelectCallback(ChoiceItem choice);

    public TMP_Text m_Text;
	private ChoiceSelectCallback m_OnSelectChoice;
    private EventSystem m_EventSystem;
    
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
            transform.localScale = Vector3.Lerp(transform.localScale, 1.15f * Vector3.one, Time.deltaTime * 3.0f);
        }
		else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, Time.deltaTime * 4.0f);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        m_Highlighted = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_Highlighted = false;
    }
	public void OnPointerClick(PointerEventData eventData)
	{
		if(eventData.button == 0)
		{
            m_OnSelectChoice?.Invoke(this);
		}
	}

    internal void Initialize(string text, ChoiceSelectCallback onSelectChoice)
	{
        transform.localScale = Vector3.one;
        m_Text.text = text;
        m_OnSelectChoice = onSelectChoice;
        m_Highlighted = false;

        gameObject.SetActive(true);
    }

}
