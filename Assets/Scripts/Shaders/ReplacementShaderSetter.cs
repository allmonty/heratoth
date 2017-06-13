using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class ReplacementShaderSetter : MonoBehaviour
{
    public Shader XRayShader;
    public string tag = "XRay";

    void OnEnable()
    {
        GetComponent<Camera>().SetReplacementShader(XRayShader, tag);
    }
}