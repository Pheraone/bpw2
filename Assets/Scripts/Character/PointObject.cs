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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //doors will be activated and points will be added
            DoorsBehaviour.ClosingDoors.ActivateDoors(false);
            PlayerMovement.Instance.points++;
            Destroy(gameObject);
          
        }

    }
}
