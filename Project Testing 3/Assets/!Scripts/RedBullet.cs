using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullet : MonoBehaviour
{
    public float life = 3;
    public int bulletDamage = 100;
    public ParticleSystem splat;

    private void Awake()
    {
        Destroy(gameObject, life);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RedEnemy") || collision.gameObject.CompareTag("BigRedEnemy"))
        {
            ApplyDamageToEnemy(collision.gameObject);
            PlayImpactEffect();
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }

    private void ApplyDamageToEnemy(GameObject enemy)
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

    private void PlayImpactEffect()
    {
        ParticleSystem impactEffect = Instantiate(splat, transform.position, Quaternion.identity);
        impactEffect.Play();
        Destroy(impactEffect, 1);
    }
}
