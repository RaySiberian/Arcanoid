using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{
    private void Update()
    {
        Vector3 posInPixels = Input.mousePosition;
        Vector3 posInWorld = Camera.main.ScreenToWorldPoint(posInPixels);

        Vector3 padPosition = posInWorld;
        padPosition.y = transform.position.y;
        padPosition.z = transform.position.z;
        padPosition.x = Mathf.Clamp(padPosition.x, -6.3f, 6.3f);
        
        transform.position = padPosition;
    }
}
