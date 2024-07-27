using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Interactable : MonoBehaviour
{
    public SpriteRenderer renderer;
    protected bool interactable = true;
    // Action that will be performed on interaction, to display in the HUD as a hint.
    [SerializeField] public string action;

    private static readonly int OutlineThickness = Shader.PropertyToID("_OutlineThickness");
    public bool IsInteractable => interactable;

    public virtual void Interact()
    {

    }

    public void Hover()
    {
        renderer.material.SetFloat(OutlineThickness, 1);
    }

    public void UnHover()
    {
        renderer.material.SetFloat(OutlineThickness, 0);
    }
}
