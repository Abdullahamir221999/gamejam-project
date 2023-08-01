using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBullet : MonoBehaviour
{
    public float life = 3;
    private Rigidbody greenbulletRb;
    private GameObject target;
    public float speed = 0.5f;
    
    void Start()
    {
        greenbulletRb = GetComponent<Rigidbody>();
        target = GameObject.Find("GreenEnemy");
    }
    void Update()
    {
        greenbulletRb.AddForce((target.transform.position - transform.position) * speed);
    }
    void Awake()
    {
        Destroy(gameObject, life);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GreenEnemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
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
}
