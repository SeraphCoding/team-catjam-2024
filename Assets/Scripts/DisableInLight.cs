using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableInLight : LightDetector
{
    [SerializeField]
    private Behaviour[] toDisable;
    [SerializeField]
    private bool red;
    [SerializeField]
    private bool green;
    [SerializeField]
    private bool blue;

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        if ((!red || (red && hitBy["Red"])) && (!green || (green && hitBy["Green"])) && (!blue || (blue && hitBy["Blue"])))
            SetAll(false);
        else
            SetAll(true);
    }

    void SetAll(bool active)
    {
        foreach (Behaviour b in toDisable) {
            b.enabled = active;
        }
    }
}
