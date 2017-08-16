
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CelestrialObject : MonoBehaviour {


    public new string name = "Object";
    public float radius = 1f;
    public float tilt = 0f;
    public PlanetTime dayLength;

    public Vector3 velocity = new Vector3(0f,0f,0f);
    public Vector3 acceleration = new Vector3(0f, 0f, 0f);

    private Rigidbody rb;
    private float mass;

     void Start()
    {
        rb = GetComponent<Rigidbody>();
        mass = rb.mass;
    }

    // Use this for initialization
    void FixedUpdate () {
        rb.AddForce(velocity);
        rb.AddForce(acceleration);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Gravitation()
    {

    }

    void Rotation()
    {

    }
}

