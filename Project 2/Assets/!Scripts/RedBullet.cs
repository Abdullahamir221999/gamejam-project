using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullet : MonoBehaviour
{
    public float life = 3;
    private Rigidbody redbulletRb;
    private GameObject target;
    public float speed = 0.5f;
    void Start()
    {
        redbulletRb = GetComponent<Rigidbody>();
        target = GameObject.Find("RedEnemy");
    }
    void Update()
    {
        redbulletRb.AddForce((target.transform.position - transform.position) * speed);
    }
    void Awake()
    {
        Destroy(gameObject, life);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RedEnemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("GreenEnemy"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("BlueEnemy"))
        {
            Destroy(gameObject);
        }
    }
}
