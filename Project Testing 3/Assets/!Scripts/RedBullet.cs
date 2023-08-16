using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullet : MonoBehaviour
{
    public float life = 3;
    public int bulletDamage = 100;
    public ParticleSystem splat;
    void Awake()
    {
        Destroy(gameObject, life);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RedEnemy"))
        {
            ApplyDamageToEnemy(collision.gameObject);
            fx();
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
    void ApplyDamageToEnemy(GameObject enemy)
    {
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            enemyScript.TakeDamage(bulletDamage);
        }
    }
    void fx()
    {
        ParticleSystem f = Instantiate(splat, transform.position, Quaternion.identity);
        f.Play();
        Destroy(f, 1);
    }
}
