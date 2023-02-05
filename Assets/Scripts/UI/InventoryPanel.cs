using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{

    public List<QuestionItem> m_Questions = new List<QuestionItem>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenInventory()
    {
        ShowInventory(GameManager.GetInstance().GetQuestions());
    }

    public void ShowInventory(Progression.InventoryQuestion[] questions)
    {
        for(int i = 0; i < questions.Length; i++)
        {
            if(i >= m_Questions.Count)
            {
                QuestionItem newItem = Instantiate<QuestionItem>(m_Questions[0]);
                newItem.transform.SetParent(m_Questions[0].transform.parent);
                newItem.transform.localScale = Vector3.one;
                m_Questions.Add(newItem);
            }
            m_Questions[i].SetValue(questions[i]);
        }
        for(int i = questions.Length; i < m_Questions.Count; i++)
        {
            m_Questions[i].gameObject.SetActive(false);
        }

        gameObject.SetActive(true);
    }

    public void HideInventory()
    {
        gameObject.SetActive(false);
    }
}
