using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel : MonoBehaviour
{
    private static UIPanel m_Instance;

    public DialogueWindow m_Dialog;
    public PopupPanel m_Popups;
    public HUDPanel m_HUD;
    public JournalPanel m_Journal;
    public InventoryPanel m_Inventory;
    private void Awake()
    {
        m_Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        m_Journal.CloseJournal();
        m_Inventory.HideInventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static UIPanel GetInstance()
    {
        return m_Instance;
    }

    public void ShowGab(string text)
    {
        m_Popups.ShowGab(text);
    }

    public void ShowJournal()
    {
        m_Journal.OpenJournal();
    }
}
