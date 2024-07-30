using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class VinePot : LightDetector
{
    private Stack<VineSegment> segments;
    [SerializeField]
    private GameObject segmentPrefab;
    [SerializeField]
    private int maxSegments;
    [SerializeField]
    private float growDelay;
    private float timeSinceGrow;

    public void Start()
    {
        segments = new();
        segments.Push(GetComponentInChildren<VineSegment>());
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        timeSinceGrow += Time.fixedDeltaTime;
        if (!hitBy["Red"] && hitBy["Green"] && !hitBy["Blue"] && timeSinceGrow > growDelay) Grow();
    }

    public void Grow()
    {
        timeSinceGrow = 0;
        if (segments.Count >= maxSegments) return;
        VineSegment oldHead = segments.Peek();
        oldHead.head = false;
        VineSegment newHead = Instantiate(segmentPrefab).GetComponent<VineSegment>();
        newHead.transform.parent = oldHead.attatchPoint;
        newHead.head = true;
        newHead.pot = this;
        newHead.transform.localPosition = Vector3.zero;
        newHead.transform.localRotation = oldHead.transform.localRotation;
        segments.Push(newHead);
        foreach (VineSegment seg in segments) {
            seg.UpdateSprite();
        }
    }

    public void CutHead()
    {
        if (segments.Count <= 1) return;
        Destroy(segments.Pop().gameObject);
        segments.Peek().head = true;
        foreach (VineSegment seg in segments) {
            seg.UpdateSprite();
        }
    }
}
