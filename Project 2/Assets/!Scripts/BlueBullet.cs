using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBullet : MonoBehaviour
{
    public float life = 3;
    private Rigidbody bluebulletRb;
    private GameObject target;
    public float speed = 100f;
    void Start()
    {
        bluebulletRb = GetComponent<Rigidbody>();
        target = GameObject.Find("BlueEnemy");
    }
    void FixedUpdate()
    {
        bluebulletRb.AddForce((target.transform.position - transform.position) * speed);
    }
    void Awake()
    {
        Destroy(gameObject, life);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BlueEnemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
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
}
