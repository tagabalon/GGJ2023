using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupPanel : MonoBehaviour
{
    public TMP_Text m_GabText;
    internal void ShowGab(string text)
    {
        m_GabText.text = text;
        GetComponent<Animator>().SetTrigger("Gab");
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
