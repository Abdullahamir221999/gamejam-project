using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform [] bulletSpawnPoint;
    public GameObject [] bulletPrefab;
    //public float bulletSpeed = 0.5f;
    
    void Update()
    {
      /*if(Input.GetKeyDown(KeyCode.R))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward /** bulletSpeed;

        }*/
    }
    public void redShoot()
    {
        var bullet = Instantiate(bulletPrefab[0], bulletSpawnPoint[0].position, bulletSpawnPoint[0].rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint[0].forward /** bulletSpeed*/;
    }
    public void blueShoot()
    {
        var bullet = Instantiate(bulletPrefab[1], bulletSpawnPoint[1].position, bulletSpawnPoint[1].rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint[1].forward /** bulletSpeed*/;
    }
    public void greenShoot()
    {
        var bullet = Instantiate(bulletPrefab[2], bulletSpawnPoint[2].position, bulletSpawnPoint[2].rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint[2].forward /** bulletSpeed*/;
    }

}
