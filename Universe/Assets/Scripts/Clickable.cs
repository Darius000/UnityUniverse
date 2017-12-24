using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Clickable : MonoBehaviour {

    public int mouseButton;

    private new Camera camera;
    private GameObject currentPlanet;
    private CameraTarget cameraTarget;

    void Start()
    {
        camera = GetComponent<Camera>();
        cameraTarget = GetComponent<CameraTarget>();
    }

	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(mouseButton))
        {
            FireRay();
        }
	}

    void FireRay()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if(GetHit(ray, hit))
        {
            cameraTarget.SetCurrentPlanet(currentPlanet);
            cameraTarget.Follow(currentPlanet);
        }
    }

    bool GetHit(Ray ray,RaycastHit hit)
    {
        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider != null)
            {
                if(hit.collider.tag == "Clickable")
                {
                    currentPlanet = hit.collider.gameObject ;
                    print(currentPlanet.name);
                    return true;
                }

            }         
        }

        return false;
    }
}
