using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Interactable
{
    [SerializeField] private List<Lantern> lanterns;
    [SerializeField] private string nextScene;
    //public float rotationSpeed = 2.0f;

    void Update()
    {
        bool active = false;

        foreach (Lantern lantern in lanterns) {
            active = active || lantern.IsInteractable;
        }

        interactable = !active;
    }

    public override void Interact()
    {
        base.Interact();
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
    }
}
