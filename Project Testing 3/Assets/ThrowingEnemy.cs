using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingEnemy : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float throwingForce = 10f;
    public float throwingRange = 5f; // Set the throwing range.
    public float moveSpeed = 2f; // Adjust the movement speed.
    public float throwInterval = 2.5f; // Time interval between throws.

    private Transform turret; // Reference to the turret transform
    private bool canThrow = false;
    private bool isMoving = true;
    private float throwTimer = 0f;

    private void Start()
    {
        turret = GameManager.Instance.turretPosition; // Assign the turret position here.
    }

    private void Update()
    {
        if (isMoving)
        {
            float distanceToTurret = Vector3.Distance(transform.position, turret.position);

            if (distanceToTurret <= throwingRange)
            {
                isMoving = false; // Stop moving once within throwing range.
            }
            else
            {
                MoveTowardsTurret();
            }
        }
        else
        {
            throwTimer += Time.deltaTime;
            if (throwTimer >= throwInterval)
            {
                throwTimer = 0f;
                ThrowProjectile();
            }
        }
    }

    private void MoveTowardsTurret()
    {
        Vector3 directionToTurret = (turret.position - transform.position).normalized;
        Vector3 movement = directionToTurret * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    private void ThrowProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();

        Vector3 directionToTurret = (turret.position - transform.position).normalized;
        projectileRigidbody.velocity = directionToTurret * throwingForce;

        Debug.Log("Throwing projectile");
    }
}
