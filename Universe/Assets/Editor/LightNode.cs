using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("Advanced", "MainLight")]
public class LightNode : CodeFunctionNode
{
    public LightNode()
    {
        name = "MainLight";
    }

    private static string functionBody = @"
		{
            float3 lightDir = normalize(LightPosition - Position);
			float NdotL = dot(Position, lightDir);
            Intensity = NdotL;
		}
    ";

    protected override MethodInfo GetFunctionToConvert()
    {
        return GetType().GetMethod("Light", BindingFlags.Static | BindingFlags.NonPublic);
    }

    static string Light
    (
        [Slot(0, Binding.WorldSpacePosition)] Vector3 Position,
        [Slot(1, Binding.None)] Vector3 LightPosition,
        [Slot(2, Binding.None)]out Vector1 Intensity
    )
    {

        return functionBody;
    }
}
