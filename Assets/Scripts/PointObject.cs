using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointObject : MonoBehaviour
{
    public ParticleSystem effect = new ParticleSystem();
    // Start is called before the first frame update
    void Start()
    {
        effect.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
     
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DoorsBehaviour.ClosingDoors.ActivateDoors(false);
            PlayerMovement.Instance.points++;
            Destroy(gameObject);
          
        }

    }
}
