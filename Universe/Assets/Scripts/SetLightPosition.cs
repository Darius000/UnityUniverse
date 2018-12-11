using UnityEngine;

public class SetLightPosition : MonoBehaviour {

    public GameObject Star;

    private Material material;

    private void Awake()
    {
        material = GetComponent<MeshRenderer>().material;

        material.SetVector("LightPosition", Star.transform.position);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
