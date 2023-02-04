using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;

	private void Start()
	{
		
	}

	private void Update()
	{
		if(isInRange)
		{
			if(Input.GetKeyDown(interactKey))
			{
				interactAction.Invoke();
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
		{
			isInRange = true;
			Debug.Log("Player is in range.");
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			isInRange = false;
			Debug.Log("Player is not in range.");
		}
	}

}
