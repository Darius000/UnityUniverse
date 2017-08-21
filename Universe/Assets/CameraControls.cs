using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour {


    public float smoothness = 1.0f;
    public float zoom = 1.0f;

    public static Camera main;

	// Use this for initialization
	void Start () {
        main = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        zoom += Input.GetAxis("Mouse ScrollWheel");
        
	}
}
