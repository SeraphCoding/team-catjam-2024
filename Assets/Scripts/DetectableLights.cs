using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DetectableLights : MonoBehaviour
{
    public static DetectableLights instance;
    public Light2D[] lights;

    void Awake()
    {
        instance = this;
    }
}
