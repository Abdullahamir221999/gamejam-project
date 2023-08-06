using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public Transform [] bulletSpawnPoint;
    public GameObject [] bulletPrefab;
    
    void Update()
    {
        
    }
    public void redShoot()
    {
        var bullet = Instantiate(bulletPrefab[0], bulletSpawnPoint[0].position, bulletSpawnPoint[0].rotation);
    }
    public void blueShoot()
    {
        var bullet = Instantiate(bulletPrefab[1], bulletSpawnPoint[1].position, bulletSpawnPoint[1].rotation);
    }
    public void greenShoot()
    {
        var bullet = Instantiate(bulletPrefab[2], bulletSpawnPoint[2].position, bulletSpawnPoint[2].rotation);
    }

}
