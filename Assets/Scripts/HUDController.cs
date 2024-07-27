using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    public DialogController dialogController;
    public HintController hintController;
    public Player player;

    private void Update()
    {
        if (!player) return;
        player.freezePlayer = dialogController.showDialog;
        if (player.Interactable)
        {
            hintController.gameObject.SetActive(true);
            hintController.SetText(player.Interactable.action);
        }
        else
        {
            hintController.gameObject.SetActive(false);
        }
    }
}
