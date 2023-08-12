using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingLogo : MonoBehaviour
{
    float originalY;
    Vector3 originalScale;

    public float floatStrength = 1;
    public float scaleStrength = 0.1f;
    public float scaleSpeed = 1.0f;

    void Start()
    {
        originalY = transform.position.y;
        originalScale = transform.localScale;
    }

    void Update()
    {
        // Floating effect
        float yOffset = (float)Mathf.Sin(Time.time) * floatStrength;
        transform.position = new Vector3(transform.position.x,
            originalY + yOffset,
            transform.position.z);

        // Scaling effect
        float scaleOffset = (float)Mathf.Sin(Time.time * scaleSpeed) * scaleStrength;
        Vector3 newScale = originalScale + new Vector3(scaleOffset, scaleOffset, scaleOffset);
        transform.localScale = newScale;
    }



}
