using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeBullet : MonoBehaviour
{
    public float life = 3;
    private Rigidbody orangebulletRb;
    public int bulletDamage = 100;
    public ParticleSystem splat;
    void Start()
    {
        orangebulletRb = GetComponent<Rigidbody>();
    }
    void Awake()
    {
        Destroy(gameObject, life);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("OrangeEnemy") /*|| collision.gameObject.CompareTag("BigPurpleEnemy")*/)
        {
            ApplyDamageToEnemy(collision.gameObject);

            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);

            fx();

        }
    }
    void ApplyDamageToEnemy(GameObject enemy)
    {
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            enemyScript.TakeDamage(bulletDamage);
        }
        BiggerEnemy bigEnemyScript = enemy.GetComponent<BiggerEnemy>();
        if (bigEnemyScript != null)
        {
            bigEnemyScript.TakeDamage(bulletDamage);
        }
    }
    void fx()
    {
        ParticleSystem f = Instantiate(splat, transform.position, Quaternion.identity);
        f.Play();
    }

}
