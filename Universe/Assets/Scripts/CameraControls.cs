using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour {


    public float smoothness = 1.0f;
    public float zoomSpeed = 1.0f;

    public static Camera main;
    public Transform target;

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
        if(Input.GetAxis("Mouse ScrollWheel") != 0.0f)
        {
            ZoomCamera(main, Input.GetAxis("Mouse ScrollWheel") * zoomSpeed);
        }

        if(Input.GetMouseButton(0))
        {
            RotateCamera(main, Input.GetAxis("Mouse X") * 100.0f,target);

            print("Rotate");
        }    
	}

    void ZoomCamera(Camera camera,float axis)
    {    
        Vector3 newPosition = new Vector3(0.0f, 0.0f, axis);

        camera.transform.Translate(newPosition);

        if(targetScript.planet != null)
        {
            camera.transform.LookAt(targetScript.planet.transform.position);
        }
        
    }

    void PanCamera(Camera camera, float axis)
    {

    }


    void RotateCamera(Camera camera, float speed,Transform target = null)
    {
        if(target != null)
        {
            camera.transform.RotateAround(target.position, Vector3.up, speed);
        }
        else
        {
            camera.transform.Rotate(Vector3.up * speed);
        }
        
    }
  
}
