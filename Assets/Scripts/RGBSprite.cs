using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RGBSprite : MonoBehaviour
{
    static string[] layers = { "Green@0.5", "Blue@0.3" };

    void Start()
    {
        SpriteRenderer original = GetComponent<SpriteRenderer>();

        foreach (string layer in layers) {
            string[] split = layer.Split("@");

            float alpha = float.Parse(split[1]);

            GameObject gameObject = new GameObject(layer);
            SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = original.sprite;
            Color colour = original.color;
            colour.a = alpha;
            spriteRenderer.color = colour;
            spriteRenderer.sortingLayerName = split[0];
            gameObject.transform.SetParent(transform);
            gameObject.transform.localScale = Vector3.one;
        }
    }
}
