
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CelestrialObject : MonoBehaviour {


    public new string name = "Object"; // planet name
    public float radius = 1f; // radius in miles ex: Earth miles = 3959f = 1f
    public float tilt = 0f; // planet axial tilt in degrees
    public float day = 24f; // length of day in hours : ex: Earth = 24 hours or 23.59 hours
    

    public Vector3 velocity = new Vector3(0f,0f,0f);
    public Vector3 acceleration = new Vector3(0f, 0f, 0f);

    public Rigidbody rb;
    private float mass;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mass = rb.mass;
        
    }
	
	// Update is called once per frame
	void Update () {
        Rotation(day);
	}

    void Gravitation()
    {

    }

    void Rotation(float hours)
    {
        float speed = 360f / (hours * 3600f);
        transform.Rotate(0f,speed,0f);
    }
}

