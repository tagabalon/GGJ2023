using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisplayTraits : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] public Image dialoguePanel;
    public delegate void DisplayTraitHover(DisplayTraits displayTraits);

    public DisplayTraitHover displayTraitHover;
    public void OnPointerEnter(PointerEventData eventData)
    {
        displayTraitHover(this);        
        dialoguePanel.gameObject.SetActive(true);
        Debug.Log("OnMouseEnter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        dialoguePanel.gameObject.SetActive(false);
        Debug.Log("OnMouseExit");
    }
}
