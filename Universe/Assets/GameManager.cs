using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Collections;
using UnityEngine.UI;

[System.Serializable]
public class GameManager : MonoBehaviour {

  
    public List<GameObject> planets;
    public Dropdown dropDownList;
    public GameObject selectedPlanet;
    public int SelectedIndex = 0;

    public void AddOptions()
    {
        foreach(GameObject planet in planets)
        {
            if(dropDownList != null)
            {
                Dropdown.OptionData data = new Dropdown.OptionData();
                data.text = planet.name;
                dropDownList.options.Add(data);
            }
        }
    }

    public void GetValue()
    {
        SelectedIndex = dropDownList.value;
        selectedPlanet = planets[SelectedIndex];

        print(SelectedIndex + ":" + selectedPlanet.name);
    }

    private void Start()
    {
        AddOptions();
    }
}
