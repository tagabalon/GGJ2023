using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionItem : MonoBehaviour
{
    public TMP_Text m_Text;
    public TMP_Text m_Count;
    internal void SetValue(Progression.InventoryQuestion inventoryQuestion)
    {
        m_Text.text = inventoryQuestion.m_Question.m_QuestionText;
        m_Count.text = "x" + inventoryQuestion.m_Count;

        gameObject.SetActive(true);
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
