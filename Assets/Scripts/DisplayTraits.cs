using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisplayTraits : MonoBehaviour
{
    public DraggablePortrait m_Content;

    internal void SetNPC(Progression.UnlockedNPC unlockedNPC, 
        DraggablePortrait.TooltipCallback onDisplayTooltip, 
        DraggablePortrait.DropppedCallback onDroppedPortrait)
    {
        if(unlockedNPC != null)
        {
            m_Content.SetNPC(unlockedNPC, onDisplayTooltip, onDroppedPortrait);
        }
        else
        {
            m_Content.Hide();
        }
    }
}
