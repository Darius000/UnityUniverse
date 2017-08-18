
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class CelestrialObject : MonoBehaviour {

    
    public static List<CelestrialObject> CelestrialObjects;
    public new string name = "Object"; // planet name
    public float radius = 1f; // radius in miles ex: Earth miles = 3959f = 1f
    public float tilt = 0f; // planet axial tilt in degrees
    public float day = 24f; // length of day in hours : ex: Earth = 24 hours or 23.59 hours
    

    public Vector3 velocity = new Vector3(0f,0f,0f);


    public Rigidbody rb;
    public float mass;

    private void OnEnable()
    {
        if (CelestrialObjects == null)
            CelestrialObjects = new List<CelestrialObject>();

        CelestrialObjects.Add(this);
    }

    private void OnDisable()
    {
        CelestrialObjects.Remove(this);    
    }

    private void FixedUpdate()
    {
        foreach(CelestrialObject Obj in CelestrialObjects)
        {
            if (Obj != this)
                Gravitation(Obj);
        }

        rb.AddForce(velocity);
        Rotation(day);
    }

    void Gravitation(CelestrialObject otherObject)
    {
        Vector3 direction = otherObject.rb.transform.position - rb.transform.position;
        float distance = Mathf.Pow((otherObject.rb.transform.position - rb.transform.position).magnitude, 2f);

        if (distance == 0f)
            return;

        float GConstant = 6.647f;
        float Mass = otherObject.mass * mass;
       
        float magnitude = GConstant * (Mass / distance);
        Vector3 force = magnitude * direction.normalized;
        rb.AddForce(force);
    }

    void Rotation(float hours)
    {
        float speed = 360f / (hours * 3600f);
        rb.transform.Rotate(0f,speed,0f);
        
    }
}

