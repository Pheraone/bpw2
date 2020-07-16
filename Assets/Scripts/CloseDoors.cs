using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class CloseDoors : MonoBehaviour
{
     private bool doorToggle = false;
     private  GameObject[] doors;

    void Awake()
    {
        doors = GameObject.FindGameObjectsWithTag("Door");
    }

    // Update is called once per frame
   void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            doorToggle = !doorToggle;
            ActivateDoors(doorToggle);
        }
    }

    public void ActivateDoors(bool active)
    {
        foreach (GameObject door in doors)
        {
            door.SetActive(active);
           
        }
        Debug.Log("Deur " + doors.Length);
    }
}
