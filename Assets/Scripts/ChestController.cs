using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
	public bool isOpen;

	public Question m_Loot;
	public int m_Amount;
	public void OpenChest()
	{
		if (!isOpen)
		{
			isOpen = true;

			GameManager.GetInstance().AddQuestion(m_Loot, m_Amount);
			UIPanel.GetInstance().ShowLoot(m_Loot, m_Amount);
		}
	}
}
