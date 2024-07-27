using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Lantern : Interactable
{
    public Light2D light;
    public Sprite unlitSprite;

    public override void Interact()
    {
        base.Interact();
        light.gameObject.SetActive(false);
        GetComponent<SpriteRenderer>().sprite = unlitSprite;
        _interactable = false;
    }
}
