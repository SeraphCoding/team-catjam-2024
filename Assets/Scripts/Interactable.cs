using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Interactable : MonoBehaviour
{
    public SpriteRenderer renderer;
    public float rotationSpeed = 1f;
    protected bool interactable = true;

    /// <summary>
    /// Allows the interactable to be rotated by the player.
    /// </summary>
    public bool isRotatable = false;
    // Action that will be performed on interaction, to display in the HUD as a hint.
    [SerializeField] public string interactAction;
    public string rotateAction = "Rotate";
    private bool _isBeingRotated = false;
    private static readonly int OutlineThickness = Shader.PropertyToID("_OutlineThickness");
    public bool IsInteractable => interactable;
    public bool IsBeingRotated => _isBeingRotated;
    

    public virtual void Interact()
    {

    }

    public virtual void Rotate()
    {
        Debug.Log("Interactable Rotate");
        if (!isRotatable) return;
        Debug.Log("Interactable Toggled Rotation State");
        _isBeingRotated = !_isBeingRotated;
        Debug.Log(_isBeingRotated);
    }

    /// <summary>
    /// Handles the physical rotation of the interactable transform
    /// </summary>
    public virtual void DoRotation()
    {
        if (!_isBeingRotated) return;
        Vector2 _movement = Player._playerControls.Movement.Move.ReadValue<Vector2>();
        transform.Rotate(_movement.x * Time.fixedDeltaTime * rotationSpeed, 0, 0);
    }

    private void FixedUpdate()
    {
        DoRotation();
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
