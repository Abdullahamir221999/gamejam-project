using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBullet : MonoBehaviour
{
    public float life = 3;
    private Rigidbody greenbulletRb;
    public int bulletDamage = 100;


    void Start()
    {
        greenbulletRb = GetComponent<Rigidbody>();
    }

    void Awake()
    {
        Destroy(gameObject, life);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GreenEnemy"))
        {
            ApplyDamageToEnemy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("RedEnemy"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("BlueEnemy"))
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
