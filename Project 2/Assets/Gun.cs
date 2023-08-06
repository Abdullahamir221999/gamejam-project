using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject[] bulletPrefabs;
    private int selectedBulletIndex = 0;

    public float shootInterval = 0.2f;
    private bool isShooting = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedBulletIndex = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedBulletIndex = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedBulletIndex = 2;
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