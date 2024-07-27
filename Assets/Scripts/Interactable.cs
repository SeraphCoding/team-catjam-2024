using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Interactable : MonoBehaviour
{
    public SpriteRenderer renderer;
    [FormerlySerializedAs("_interactable")] [SerializeField]
    protected bool interactable = true;

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
