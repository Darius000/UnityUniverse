
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
public class Planet : MonoBehaviour {

    [Header("Appearance")]
    public new string name = "Object"; // planet name
    public float radius = 1f; // radius in miles ex: Earth miles = 3959f = 1f

    [Header("Planet Rotation")]
    [Space]
    public float day = 24f; // length of day in hours : ex: Earth = 24 hours or 23.59 hours
    public float axialTilt = 0f;
    public bool showTilt = true;
    public float tiltDistance = 10f; //show tilt gizmo at distance

    [Header("Planet Revolution")]
    [Space]
    public bool ShowPath = false;
    [Range(0f, 1f)]
    public float eccentricity = 0f;
    public float distance = 0f;
    public float year = 8760 ;

    [Header("Parent Object")]
    [Space]
    public Planet parent;

    private LineRenderer line;
    private int size = 60;
    private float width = .03f;

    
    void Awake()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.positionCount = size;
        line.startWidth = width;
        line.endWidth = width;
        transform.localScale = Vector3.one * radius;
    }

    void Start()
    {

    }

    void Update()
    {
            if (parent != null)
            {
                Revolution(distance);
            }


            Rotation(day);
    }

    void OnDrawGizmos()
    {
        ShowAxialTilt(showTilt, tiltDistance);

    }

    void Rotation(float hours)
    {
        if (hours > 0f)
        {
            float speed = 360f / (hours * 60f);
            transform.Rotate(0f, speed, 0f);
        }
        else
        {
            return;
        }
    }

    void Revolution(float distance)
    {
        transform.position = RevolutionPosition();

        if (ShowPath)
        {
            float deltaTheta = (2.0f * Mathf.PI) / (size - 1);
            float theta = 0f;

            for (int i = 0; i < size; i++)
            {

                Vector3 linePos = RevolutionPath(theta);
                line.SetPosition(i, linePos);

                theta += deltaTheta;
            }
        }
    }

    Vector3 RevolutionPosition()
    {
          //year = year * 60f;
         return new Vector3(parent.transform.position.x + Mathf.Sin(-Time.fixedTime * (1/year) * (eccentricity + 1f)) * distance, 0f, parent.transform.position.z + Mathf.Cos(-Time.fixedTime * (1 / year) * (eccentricity + 1f)) * distance);

    }

    Vector3 RevolutionPath(float theta)
    {

        return new Vector3(parent.transform.position.x + Mathf.Sin(theta  * (eccentricity + 1f)) * distance, 0f, parent.transform.position.z + Mathf.Cos(theta  * (eccentricity + 1f)) * distance);

    }



    void ShowAxialTilt(bool show, float distance)
    {
        if (show)
        {
           
            Vector3 direction = transform.up * distance;

            Debug.DrawRay(transform.position, direction, Color.red);
        }
    }
}




