using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject[] bulletPrefabs; // Array of different bullet prefabs (Red, Blue, Green).
    private int selectedBulletIndex = 0; // Index to keep track of the selected bullet.

    public float shootInterval = 0.2f; // Time interval between shots.
    private bool isShooting = false; // Flag to check if the gun is currently shooting.

    private void Update()
    {
        // Use Input to select the bullet color using buttons (e.g., 1 for Red, 2 for Blue, 3 for Green).
        // Replace these with your actual button inputs as needed.
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedBulletIndex = 0; // Red bullet selected
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedBulletIndex = 1; // Blue bullet selected
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedBulletIndex = 2; // Green bullet selected
        }

        // Check if the fire button (e.g., Space) is pressed to start auto-shooting.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isShooting = true;
            StartCoroutine(ShootRoutine());
        }

        // Check if the fire button is released to stop shooting.
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isShooting = false;
        }
    }

    private IEnumerator ShootRoutine()
    {
        // Continuously shoot bullets while isShooting is true.
        while (isShooting)
        {
            Instantiate(bulletPrefabs[selectedBulletIndex], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(shootInterval);
        }
    }
}