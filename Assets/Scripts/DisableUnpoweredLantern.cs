using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableUnpoweredLantern : LightDetector
{
    /// <summary>
    /// The lantern that this script should render unpowered when its not being hit by the specified light.
    /// </summary>
    [SerializeField] private Lantern lantern;
    [SerializeField]
    private bool red;
    [SerializeField]
    private bool green;
    [SerializeField]
    private bool blue;
    [SerializeField]
    private bool reverse;

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        if ((!red || (red && hitBy["Red"])) && (!green || (green && hitBy["Green"])) && (!blue || (blue && hitBy["Blue"])))
            lantern.ToggleLanternPower(false ^ reverse);
        else
            lantern.ToggleLanternPower(true ^ reverse);
    }
}
