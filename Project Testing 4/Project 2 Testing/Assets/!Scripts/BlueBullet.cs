using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBullet : MonoBehaviour
{
    public float life = 3;
    private Rigidbody bluebulletRb;
    public int bulletDamage = 100;

    void Start()
    {
        bluebulletRb = GetComponent<Rigidbody>();
    }
    void Awake()
    {
        Destroy(gameObject, life);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BlueEnemy"))
        {
            ApplyDamageToEnemy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("RedEnemy"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("GreenEnemy"))
        {
            Destroy(gameObject);
        }
    }
    void ApplyDamageToEnemy(GameObject enemy)
    {
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            enemyScript.TakeDamage(bulletDamage);
        }
    }

}
