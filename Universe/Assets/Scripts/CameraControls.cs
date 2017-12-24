using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour {


    public float smoothness = 1.0f;
    public float zoomSpeed = 1.0f;

    public static Camera main;

    private Vector3 newPosition;
    private CameraTarget targetScript;

    // Use this for initialization
    void Start ()
    {
        main = GetComponent<Camera>();
        targetScript = GetComponent<CameraTarget>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        ZoomCamera(main, Input.GetAxis("Mouse ScrollWheel") * zoomSpeed);
	}

    void ZoomCamera(Camera camera,float axis)
    {    
        newPosition += new Vector3(0.0f, 0.0f, axis);

        camera.transform.Translate(newPosition);

        if(targetScript.planet != null)
        {
            camera.transform.LookAt(targetScript.planet.transform.position);
        }
        
    }

    void PanCamera(Camera camera, float axis)
    {

    }
}
