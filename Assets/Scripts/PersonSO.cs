using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Person Scriptable Object", fileName = "New Person")]

public class PersonSO : ScriptableObject
{
    [SerializeField] Image personImage;
    [SerializeField] string personName;

    // Start is called before the first frame update
    public Image GetPersonImage()
    {
        return this.personImage;
    }

    public string GetPersonName()
    {
        return this.personName;
    }


}
