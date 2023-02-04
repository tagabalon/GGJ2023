using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnDrop : MonoBehaviour, IDropHandler
{
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            PersonSlotScript rectTransform = eventData.pointerDrag.GetComponent<PersonSlotScript>();
            rectTransform.transform.position = this.transform.position;
            
        }
    }
}
