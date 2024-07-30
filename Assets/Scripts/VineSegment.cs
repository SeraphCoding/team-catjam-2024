using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineSegment : LightDetector
{
    [SerializeField]
    Sprite[] sprites;
    [SerializeField]
    Sprite headSprite;
    public bool head;
    public SpriteRenderer renderer;
    public Transform attatchPoint;
    public VinePot pot;

    public override void FixedUpdate()
    {
        if (!head) return;
        base.FixedUpdate();
        if (hitBy["Red"] && !hitBy["Green"] && !hitBy["Blue"]) pot.CutHead();
    }

    public void UpdateSprite()
    {
        if (head) renderer.sprite = headSprite;
        else renderer.sprite = sprites[Random.Range(0, sprites.Length)];
    }
}
