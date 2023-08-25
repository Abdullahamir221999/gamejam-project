using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Michsky.MUIP;


public class ColorChanger : MonoBehaviour
{
    public Renderer objectRenderer; // Reference to the object's renderer.
    public Material[] materials; // List of materials to cycle through.
    public float changeInterval = 3.0f; // Time interval between material changes.
    public int levelNo;
    public GameObject[] ButtonLeft;
    public GameObject[] ButtonRight;
    public GameObject[] ButtonMid;
    public Material[] Materials;

    private int currentMaterialIndex = 0;
    private float timer = 0.0f;
    private Renderer[] renderers;
    private void Start()
    {
       

    }

    private void Update()
    {
       
       
    }

    private void ChangeMaterial()
    {
        currentMaterialIndex = (currentMaterialIndex + 1) % materials.Length;
        objectRenderer.material = materials[currentMaterialIndex];
    }

    

}
