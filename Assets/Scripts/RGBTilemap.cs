using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RGBTilemap : MonoBehaviour
{
    static string[] layers = { "GreenFloor@0.5", "BlueFloor@0.3" };

    void Start()
    {
        GameObject original = transform.GetChild(0).gameObject;

        foreach (string layer in layers) {
            string[] split = layer.Split("@");

            float alpha = float.Parse(split[1]);

            GameObject gameObject = Instantiate(original);
            Tilemap tileMap = gameObject.GetComponent<Tilemap>();
            ;
            Color colour = original.GetComponent<Tilemap>().color;
            colour.a = alpha;
            tileMap.color = colour;
            tileMap.GetComponent<TilemapRenderer>().sortingLayerName = split[0];
            gameObject.transform.SetParent(transform);
            gameObject.transform.localScale = Vector3.one;
        }
    }
}
