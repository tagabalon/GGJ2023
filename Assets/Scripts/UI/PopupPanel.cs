using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupPanel : MonoBehaviour
{
    public TMP_Text m_GabText;
    public TMP_Text m_DialogText;
    public TMP_Text m_DialogTitle;
    internal void ShowGab(string text)
    {
        m_GabText.text = text;
        GetComponent<Animator>().SetTrigger("Gab");
    }

    internal void ShowPopup(string title, string content)
    {
        m_DialogTitle.text = title;
        m_DialogText.text = content;
        GetComponent<Animator>().SetBool("Dialog", true);
    }

    public void ClosePopup()
    {
        GetComponent<Animator>().SetBool("Dialog", false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
