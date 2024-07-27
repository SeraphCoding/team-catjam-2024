using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraDirector : MonoBehaviour
{
    public Transform playerTransform;
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = playerTransform.position + new Vector3(0, 0, -10);
    }
}
