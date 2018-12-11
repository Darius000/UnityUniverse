using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("Math", "Mix")]
public class MixNode : CodeFunctionNode
{
    public MixNode()
    {
        name = "Mix";
    }

    protected override MethodInfo GetFunctionToConvert()
    {
        return GetType().GetMethod("Mix", BindingFlags.Static | BindingFlags.NonPublic);
    }

    static string Mix(
        [Slot(0, Binding.None)]Vector3 A,
        [Slot(1, Binding.None)]Vector3 B,
        [Slot(2, Binding.None)]Vector1 F,
        [Slot(3, Binding.None)]out Vector3 Out)
    {
        Out = Vector3.zero;

        return @"
        {
            Out = max(0.0, F * A) + max(0.0, -F * B);
        }";
    }
}
