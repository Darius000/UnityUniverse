using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Collections;
using UnityEngine.UI;

[System.Serializable]
public class GameManager : MonoBehaviour {

  
    public List<Planet> planets;

    InputField inputField;

    public Camera cam;

    public float cameraDistance = 10f;

	// Use this for initialization
	void Start () {
        inputField = gameObject.GetComponent<InputField>();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetOrbitWidths()
    {
        foreach(Planet planet in planets)
        {
            planet.line.startWidth = float.Parse(inputField.text);
        }
    }

    public void moveCameraToPlanet(Planet planet)
    {
        cam.transform.position = planet.transform.position + (Vector3.one * (planet.radius + cameraDistance));
    }
}
