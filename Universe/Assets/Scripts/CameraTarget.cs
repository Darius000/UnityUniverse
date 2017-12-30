using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Camera))]
public class CameraTarget : MonoBehaviour {

    public GameObject planet;
    public Vector3 offset = Vector3.one;
    public Vector3 offset2 = Vector3.one;
    public int mouseButton;
    public Camera planetViewer;
    public GameObject gameMode;

    private GameManager gameManager;
    private GameObject currentPlanet;
    private Camera currentCamera;
    private float planetRadius;

    // Use this for initialization
    void Start()
    {
        Init();

        SetCurrentPlanet(planet);
    }
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(mouseButton))
        {
            SetCurrentPlanet(planet);
        }

        Follow(currentPlanet);
	}

    //Follow the current planet
    public void Follow(GameObject newPlanet)
    {
        if (newPlanet != null)
        {
            Vector3 newPosition = newPlanet.transform.position + (offset2 * planetRadius);

            planetViewer.transform.position = newPlanet.transform.position + (offset2 * planetRadius);

            planetViewer.transform.LookAt(currentPlanet.transform.position, Vector3.up);

            currentCamera.transform.position = newPosition;

            //currentCamera.transform.LookAt(currentPlanet.transform.position, Vector3.up);
        }
    }


    //Go Planet and Look at it
    public void SetCurrentPlanet(GameObject newPlanet)
    {
        if (newPlanet != null)
        {
            Planet planetScript = newPlanet.GetComponent<Planet>();

            currentPlanet = newPlanet;

            planetRadius = planetScript.radius;

            print(currentPlanet.name);
        }
    }

    public void GetPlanetFromList()
    {
       SetCurrentPlanet(gameManager.selectedPlanet);

    }

    void Init()
    {
        currentCamera = GetComponent<Camera>();
        gameManager = gameMode.GetComponent<GameManager>();
    }
}
