using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PeopleList : MonoBehaviour
{
    [SerializeField] List<PersonSO> people;
    [SerializeField] GameObject[] personSlots;
    int startingDisplayIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        //people = new List<PersonSO>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayPeople();
    }
    
    void DisplayPeople()
    {
        for(int i = 0; i < personSlots.Length; i++)
        {
            Image personImage = personSlots[i].GetComponentInChildren<Image>();
            TextMeshProUGUI personName = personSlots[i].GetComponentInChildren<TextMeshProUGUI>();
            int j = startingDisplayIndex + i;

            if (j < people.Count)
            {
                personImage = people[j].GetPersonImage();
                personName.text = people[j].GetPersonName();
            }
            else
            {
                personImage = null;
                personName.text = null;
            }
        }
    }

    public void OnUpButtonPressed()
    {
        if (startingDisplayIndex > 0)
            startingDisplayIndex -= 2;

    }

    public void OnDownButtonPressed()
    {
        if (startingDisplayIndex < people.Count - personSlots.Length + 1)
            startingDisplayIndex += 2;
    }
}
