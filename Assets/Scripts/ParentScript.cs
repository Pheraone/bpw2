using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CollisionDetected(ChildClass ChildScript)
    {
        Debug.Log(ChildScript.gameObject.name);
        if (ChildScript.gameObject.name == "North")
        {
            Debug.Log("Up");
        }

        if (ChildScript.gameObject.name == "South")
        {
            Debug.Log("Down");
            // pos +1 idk
        }

        if (ChildScript.gameObject.name == "West")
        {
            Debug.Log("Left");
            // pos +1 idk
        }

        if (ChildScript.gameObject.name == "East")
        {
            Debug.Log("Right");
            // pos +1 idk
        }
    }
}