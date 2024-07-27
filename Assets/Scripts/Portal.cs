using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Portal : Interactable
{
    [SerializeField]
    private List<Lantern> lanterns;
    public float rotationSpeed = 2.0f;

    void Update()
    {
        bool active = false;

        foreach (Lantern lantern in lanterns) {
            active = active || lantern.isInteractable;
        }

        _interactable = !active;
    }

    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * rotationSpeed);
    }
}
