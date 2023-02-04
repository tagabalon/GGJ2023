using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCTooltip : MonoBehaviour
{
    public List<TMP_Text> m_TraitList;
    internal void Show(Progression.UnlockedNPC npc)
    {
        PersonalityTrait[] traits = npc.GetTraits();
        for(int i = 0; i < traits.Length; i++)
		{
            if(i >= m_TraitList.Count)
			{
                TMP_Text newText = Instantiate<TMP_Text>(m_TraitList[0]);
                newText.transform.localScale = Vector3.one;
                newText.transform.SetParent(m_TraitList[0].transform.parent);
                m_TraitList.Add(newText);
			}
            m_TraitList[i].text = traits[i].TraitName;
		}
        for(int i = traits.Length; i < m_TraitList.Count; i++)
		{
            m_TraitList[i].gameObject.SetActive(false);
		}

        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
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
