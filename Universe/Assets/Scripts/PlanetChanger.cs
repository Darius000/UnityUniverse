
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CelestrialObject))]
public class PlanetChanger :Editor {

    CelestrialObject Object;


    public override void OnInspectorGUI()
    {
        //Properties
        Object = (CelestrialObject)target;
        Object.rb = Object.GetComponent<Rigidbody>();

        Object.name = EditorGUILayout.TextField("Name", Object.name);
        Object.radius = EditorGUILayout.FloatField("Radius", Object.radius);
        Object.tilt = EditorGUILayout.Slider("Axial Tilt", Object.tilt, 0f, 360f);
        Object.day = EditorGUILayout.FloatField("Day Length", Object.day);
        Object.mass = EditorGUILayout.FloatField("Mass", Object.rb.mass);
        Object.velocity = EditorGUILayout.Vector3Field("velocity", Object.velocity);

        //Change Scale
        Object.transform.localScale = Vector3.one * Object.radius;
        Object.transform.rotation = Quaternion.Euler(Object.tilt, 0f, 0f);
        
    }
}
