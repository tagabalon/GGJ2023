using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggablePortrait : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public delegate void TooltipCallback(Progression.UnlockedNPC npc, bool show, Vector2 position);
    private TooltipCallback m_OnDisplayTooltip;

    public delegate bool DropppedCallback(DraggablePortrait portrait);
    private DropppedCallback m_OnDropPortrait;

    private Transform m_Slot;
    public Progression.UnlockedNPC m_NPC;
    public TMP_Text m_Character;
    public Image m_Portrait;

    private Vector2 m_DragOffset;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void SetNPC(Progression.UnlockedNPC unlockedNPC, TooltipCallback onDisplayTooltip, DropppedCallback onDroppedPortrait)
    {
        m_Slot = GetComponentInParent<Transform>();
        m_OnDisplayTooltip = onDisplayTooltip;
        m_OnDropPortrait = onDroppedPortrait;

        m_NPC = unlockedNPC;
        m_Character.text = m_NPC.m_NPC.m_CharacterName;
        m_Portrait.sprite = m_NPC.m_NPC.m_Portrait;
        gameObject.SetActive(true);
    }

    internal void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(eventData.button == 0)
        {
            eventData.selectedObject = gameObject;
            transform.position = eventData.position - m_DragOffset;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == 0)
        {
            m_DragOffset = eventData.position - (Vector2)transform.position;
            m_OnDisplayTooltip(null, false, Vector2.zero);
            GetComponent<Image>().raycastTarget = false;
        }
    }

	public void OnPointerUp(PointerEventData eventData)
	{
        if (eventData.selectedObject = gameObject)
        {
            if (!m_OnDropPortrait(this))
            {
                GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            }
            GetComponent<Image>().raycastTarget = true;
            eventData.selectedObject = null;

        }
    }

	public void OnPointerEnter(PointerEventData eventData)
	{
        if(!eventData.dragging)
            m_OnDisplayTooltip(m_NPC, true, eventData.position);
	}

	public void OnPointerExit(PointerEventData eventData)
    {
        m_OnDisplayTooltip(null, false, Vector2.zero);
    }
}
