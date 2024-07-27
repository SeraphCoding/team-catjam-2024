using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public SpriteRenderer renderer;
    [SerializeField]
    protected bool _interactable = true;
    public bool isInteractable { get { return _interactable; } }

    public virtual void Interact()
    {

    }

    public void Hover()
    {
        renderer.material.SetFloat("_OutlineThickness", 1);
    }

    public void UnHover()
    {
        renderer.material.SetFloat("_OutlineThickness", 0);
    }
}
