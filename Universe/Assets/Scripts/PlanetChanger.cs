
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CelestrialObject))]
public class PlanetChanger :Editor {

    public override void OnInspectorGUI()
    {
        CelestrialObject Object = (CelestrialObject)target;

        //Properties

        Object.name = EditorGUILayout.TextField("name", Object.name);
        Object.radius = EditorGUILayout.Slider("radius", Object.radius, .01f,1000f);
        Object.tilt = EditorGUILayout.Slider("tilt", Object.tilt, 0f, 360f);

        //Vectors
        
        Object.velocity = EditorGUILayout.Vector3Field("velocity", Object.velocity);
        Object.acceleration = EditorGUILayout.Vector3Field("acceleration", Object.acceleration);


        //Time
        Object.dayLength.hours = EditorGUILayout.IntField("hours", Object.dayLength.hours);
        Object.dayLength.minutes = EditorGUILayout.IntField("minutes", Object.dayLength.minutes);
        Object.dayLength.seconds = EditorGUILayout.IntField("seconds", Object.dayLength.seconds);

        //Change Scale
        Object.transform.localScale = Vector3.one * Object.radius;
        Object.transform.SetPositionAndRotation(Object.transform.position, Quaternion.AngleAxis(Object.tilt, Vector3.right));
    }
}
