
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Planet))]
[CanEditMultipleObjects]
public class UpdatePlanet : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Planet planet = (Planet)target;

        if (!Application.isPlaying)
        {
            SetPlanet(planet,0f,planet.startRotation);
        }
      
            
    }

    void SetPlanet(Planet obj, float positionTheta, float rotationDegrees)
    {
            //obj.line = obj.gameObject.GetComponent<LineRenderer>();
            //obj.line.positionCount = 0;
            obj.gameObject.name = obj.name;
            obj.transform.localScale = Vector3.one * obj.radius;
            obj.transform.localRotation = Quaternion.Euler(obj.axialTilt, 0f, 0f);
            obj.transform.Rotate(Vector3.up, rotationDegrees);


        if (obj.parent != null)
                obj.transform.position = obj.RevolutionPosition(positionTheta);
        else
            obj.transform.position = obj.transform.position;
    }
}
