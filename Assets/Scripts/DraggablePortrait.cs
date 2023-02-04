using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggablePortrait : MonoBehaviour, IDragHandler, IPointerDownHandler
{
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

    internal void SetNPC(Progression.UnlockedNPC unlockedNPC)
    {
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
            Debug.Log("draggiun");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == 0)
        {
            m_DragOffset = Camera.main.ScreenToViewportPoint(eventData.position) - transform.position;
        }
    }
}
