using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class HintController : MonoBehaviour
{
    [FormerlySerializedAs("hintTextGO")] [SerializeField]
    private TextMeshProUGUI hintTextGo;
    PlayerControls _controls;

    private void Awake()
    {
        _controls = new PlayerControls();
    }

    public void SetText(string text)
    {
        string interactKey =
            _controls.Interaction.Interact.GetBindingDisplayString().ToUpper();
        hintTextGo.text = interactKey + " - " + text;
    }
}
