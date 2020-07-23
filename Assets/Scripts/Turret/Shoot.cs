using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform Target;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float range = 15f;


    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); 
    }

    void Update()
    {

        //if trigger is triggered
        if (Input.GetKeyDown(KeyCode.Space)){
          ShootBullet();
        } 
        //timer for shoot cooldown

    }
    void ShootBullet()
    {
    
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
