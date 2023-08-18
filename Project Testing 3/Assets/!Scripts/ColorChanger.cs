using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Renderer objectRenderer; // Reference to the object's renderer.
    public Material[] materials; // List of materials to cycle through.
    public float changeInterval = 3.0f; // Time interval between material changes.

    private int currentMaterialIndex = 0;
    private float timer = 0.0f;

    private void Start()
    {
        if (objectRenderer == null)
        {
            objectRenderer = GetComponent<Renderer>();
        }

        // Set initial material.
        objectRenderer.material = materials[currentMaterialIndex];
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= changeInterval)
        {
            timer = 0.0f;
            ChangeMaterial();
        }
    }

    private void ChangeMaterial()
    {
        currentMaterialIndex = (currentMaterialIndex + 1) % materials.Length;
        objectRenderer.material = materials[currentMaterialIndex];
    }
}
