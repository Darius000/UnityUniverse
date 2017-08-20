
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
    [Range(0f,360f)]
    public float startRotation = 0f;
    public float day = 24f; // length of day in hours : ex: Earth = 24 hours or 23.59 hours
    public float axialTilt = 0f;
    public bool showTilt = true;
    public float tiltDistance = 10f; //show tilt gizmo at distance

    [Header("Planet Revolution")]
    [Space]
    public bool ShowPath = false;
    
    [Range(0f, 2.0f * Mathf.PI)]
    public float startPosition = 0f;

    [Range(0f, 10f)]
    public float eccentricity = 0f;
    public float distance = 0f;
    public float year = 8760 ;

    [Header("Parent Object")]
    [Space]
    public Planet parent;

    public LineRenderer line;
    private int size = 100;
    private float width = 2f;

    
    void Awake()
    {
        if (line == null)
        {
            line = gameObject.GetComponent<LineRenderer>();
        }

        line.positionCount = size;
        line.startWidth = width;
        line.endWidth = width;
    }

    void Start()
    {

        if (ShowPath)
        {
            float deltaTheta = (2.0f * Mathf.PI) / (size - 1);
            float theta = 0f;

            for (int i = 0; i < size; i++)
            {

                Vector3 linePos = RevolutionPosition(theta);
                line.SetPosition(i, linePos);

                theta += deltaTheta;
            }
        }
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
            transform.Rotate(Vector3.up, speed);
        }
        else
        {
            return;
        }
    }

    void Revolution(float distance)
    {
        transform.position = RevolutionPosition();

    }

    public Vector3 RevolutionPosition()
    {
        if (year != 0)
        {
            return parent.transform.position + new Vector3((eccentricity + 1f) * Mathf.Cos(-Time.fixedTime * (1 / year) ) * distance, 0f, Mathf.Sin(-Time.fixedTime * (1 / year)) * distance);
        }
        else
        {
            return parent.transform.position;
        }
    }

    public Vector3 RevolutionPosition(float theta)
    {   
            return EllipseFoci() + parent.transform.position + new Vector3((eccentricity + 1f) *  Mathf.Cos(theta) * distance, 0f, Mathf.Sin(theta ) * distance);
    }

    public Vector3 EllipseFoci()
    {
        Vector3 fociPoint = new Vector3();

        float b = distance;

        float a = b / Mathf.Sin(90);

        float c = Mathf.Sqrt(a * a + b * b);

        fociPoint = new Vector3(c, 0f, 0f);

        return fociPoint;
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




