using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisplayTraits : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public delegate void DisplayTraitHover(DisplayTraits displayTraits);
    public delegate void DisplayTraitExit(DisplayTraits displayTraits);

    public DraggablePortrait m_Content;
    public DisplayTraitHover displayTraitHover;
    public DisplayTraitExit hideTrait;
    public void OnPointerEnter(PointerEventData eventData)
    {
        //displayTraitHover(this);        
        Debug.Log("OnMouseEnter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hideTrait(this);
        Debug.Log("OnMouseExit");
    }

    internal void SetNPC(Progression.UnlockedNPC unlockedNPC)
    {
        if(unlockedNPC != null)
        {
            m_Content.SetNPC(unlockedNPC);
        }
        else
        {
            m_Content.Hide();
        }
    }
}
