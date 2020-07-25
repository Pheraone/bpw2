using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ParticleSystem fireParticles  = new ParticleSystem();
    float numberOfCollisions = 0;
    float lifetime = 2;
    float timer;
    void Start()
    {
        fireParticles.Play();
        timer = lifetime;
    }


    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            fireParticles.Stop();
        }

        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        numberOfCollisions++;
        if (numberOfCollisions >= 2)
        {
            Destroy(gameObject);
        }

        if(collider.gameObject.tag == "Player")
        {
            Debug.Log("I hit the player");
        }
    }
}
