using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Bullet : MonoBehaviour
{
    public ParticleSystem fireParticles  = new ParticleSystem();
    float numberOfCollisions = 0;
    float lifetime = 2;
    float timer;
    int myDamage = 10;
    void Start()
    {
        //plays particles
        fireParticles.Play();
        timer = lifetime;
    }

    void Update()
    {
        //Timer for bullet to disappear
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        Destroy(gameObject);

        if(collider.gameObject.tag == "Player")
        {
            PlayerMovement.Instance.GetDamage(myDamage);
            Destroy(gameObject);
        }
    }
}
