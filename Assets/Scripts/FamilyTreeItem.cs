using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FamilyTreeItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public delegate void HightlightItemCallback(FamilyTreeItem treeItem, bool highlighted);

	private HightlightItemCallback m_OnHightlightItem;
	private bool hightlighted = false;

	public bool m_ItemEnabled = true;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void SetOnHighlightedCallback(HightlightItemCallback onHighlight)
	{
		m_OnHightlightItem = onHighlight;
	}
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!m_ItemEnabled)
			return;
		if (eventData.selectedObject != null)
		{
			DraggablePortrait portrait = eventData.selectedObject.GetComponent<DraggablePortrait>();
			if (portrait != null)
			{
				GetComponent<Image>().enabled = true;
				m_OnHightlightItem?.Invoke(this, true);
				hightlighted = true;
			}
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (!m_ItemEnabled)
			return;
		GetComponent<Image>().enabled = false;
		if(hightlighted)
		{
			m_OnHightlightItem(this, false);
		}
	}

	internal void SetContent(DraggablePortrait portrait)
	{
		if (!m_ItemEnabled)
			return;

		portrait.transform.parent = transform.GetComponentInChildren<Transform>();
		portrait.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
	}
}
