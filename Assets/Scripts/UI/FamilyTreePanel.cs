using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyTreePanel : MonoBehaviour
{
    public FamilyTreeObject m_Tree;
    private FamilyTreeItem[] m_TreeItems;

    private FamilyTreeItem m_HighlightedItem = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowFamilyTree()
	{
        m_TreeItems = m_Tree.GetTreeItems();
        foreach(FamilyTreeItem treeItem in m_TreeItems)
		{
            treeItem.SetOnHighlightedCallback(OnHighlightedItem);
		}
	}

	private void OnHighlightedItem(FamilyTreeItem treeItem, bool highlighted)
	{
        if(highlighted)
		{
            m_HighlightedItem = treeItem;
		}
		else
		{
            m_HighlightedItem = null;
		}
	}

	internal bool HasHightlightedSlot()
	{
		return m_HighlightedItem != null;
	}

	internal void DropPortrait(DraggablePortrait portrait)
	{
		m_HighlightedItem.SetContent(portrait);
	}
}
