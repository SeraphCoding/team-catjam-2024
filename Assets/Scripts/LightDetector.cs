using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Scripting;

public class LightDetector : MonoBehaviour
{
    [SerializeField]
    private Transform[] offsets;
    public readonly Dictionary<string, bool> hitBy = new() { { "Red", false }, { "Green", false }, { "Blue", false } };

    public void Awake()
    {
        if (offsets.Count() > 0) return;

        offsets = new Transform[] { transform }; 
    }

    public virtual void FixedUpdate()
    {
        ScanLights();
    }

    public void ScanLights()
    {
        hitBy["Red"] = hitBy["Green"] = hitBy["Blue"] = false;
        
        foreach (Light2D light in DetectableLights.instance.lights) {
            if (!light.isActiveAndEnabled) continue;

            int layerMask = 1 << 10;
            if (light.name == "Green") layerMask <<= 1;
            if (light.name == "Blue") layerMask <<= 2;

            foreach (Transform offset in offsets) {
                float distance = (light.transform.position - transform.position).magnitude;
                Debug.Log($"{Mathf.Pow(FalloffThreshold(light.pointLightInnerRadius,light.pointLightOuterRadius, light.falloffIntensity), 2)},{(light.transform.position - transform.position).sqrMagnitude}");
                if (FalloffThreshold(light.pointLightInnerRadius,light.pointLightOuterRadius, light.falloffIntensity)
                    < distance)
                    continue;

                RaycastHit2D hit = Physics2D.Raycast(offset.position, light.transform.position - offset.position, distance, layerMask);

                if (hit.collider) continue;

                Debug.Log($"{FalloffThreshold(light.pointLightInnerAngle, light.pointLightOuterAngle, light.falloffIntensity) / 2},{Vector3.Angle(light.transform.up, transform.position - light.transform.position)}");

                if (FalloffThreshold(light.pointLightInnerAngle, light.pointLightOuterAngle, light.falloffIntensity) / 2
                    < Vector3.Angle(light.transform.up, transform.position - light.transform.position))
                    continue;

                hitBy[light.name] = true;
                break;
            }
        }

        Debug.Log($"Red: {hitBy["Red"]}\nGreen: {hitBy["Green"]}\nBlue: {hitBy["Blue"]}");
    }

    public float FalloffThreshold(float inner, float outer, float falloffIntensity)
    {
        return (1 - falloffIntensity) * outer + falloffIntensity * inner; // inner + (1 - falloffIntensity) * (outer - inner)
    }
}
