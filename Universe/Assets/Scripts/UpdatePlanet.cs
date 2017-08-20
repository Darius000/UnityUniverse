
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Planet))]
[CanEditMultipleObjects]
public class UpdatePlanet : Editor {

    Planet planet;


    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Planet planet = (Planet)target;

        if (!Application.isPlaying)
        {
            planet.transform.localScale = Vector3.one * planet.radius;
            planet.transform.localRotation = Quaternion.Euler(planet.axialTilt, 0f, 0f);
            if (planet.parent != null)
                planet.transform.position = Vector3.forward * (planet.parent.transform.position.z + planet.distance);

        }
      
            
    }
}
