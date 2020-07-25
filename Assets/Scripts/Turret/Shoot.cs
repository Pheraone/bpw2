using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform Target;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float range = 15f;
    Vector3 direction;
    float fireRate = 1f;
    float RotationSpeed = 10f;
    public float speed = 30f;
    float numberOfCollisionsT;
    bool targetSpotted;
    

    IEnumerator coroutine;

    private void Start()
    {
        
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        coroutine = ShootBullet();
       
    }

    void Update()
    {

        Debug.Log(gameObject.name + targetSpotted);
        if (targetSpotted)
        {
            // lekker draaien
            direction = (Target.position - transform.position).normalized;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, direction), Time.deltaTime * RotationSpeed);

        }

    }
   

    IEnumerator ShootBullet()
    {
        while(true)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Vector2 dir = new Vector2(direction.x, direction.y);
            bullet.GetComponent<Rigidbody2D>().velocity = dir * speed;
            yield return new WaitForSeconds(fireRate);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            targetSpotted = true;
            StartCoroutine(coroutine);
            Debug.Log("Started");
        }
    }


    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag =="Player")
        {
           targetSpotted = false;
            StopCoroutine(coroutine);
            Debug.Log("Stopped");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        numberOfCollisionsT++;
        if(numberOfCollisionsT >= 2)
        {
            Destroy(gameObject);
        }

    }

}



