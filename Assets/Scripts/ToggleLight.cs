using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ToggleLight : Interactable
{
    public Light2D light;

    public override void Interact()
    {
        base.Interact();
        light.gameObject.SetActive(!light.gameObject.activeSelf);
    }
}
