using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSceneManager : MonoBehaviour
{
    public HUDController hud;
    // Start is called before the first frame update
    void Start()
    {
        hud.ShowDialog();
    }
}
