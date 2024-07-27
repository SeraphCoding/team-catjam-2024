using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSceneManager : MonoBehaviour
{
    public DialogController dialogController;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        dialogController.showDialog = true;
        dialogController.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!player) return;
        player.freezePlayer = dialogController.showDialog;
    }
}
