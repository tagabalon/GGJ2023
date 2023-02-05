using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameScript : ScriptableObject
{
    [System.Serializable]
    public class ShowText
    {
        public string m_Speaker;
        public string m_Text;
    }

    public List<ShowText> m_ShowTexts = new List<ShowText>();
}
