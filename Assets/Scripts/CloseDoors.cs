using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class CloseDoors : MonoBehaviour
{
    private static CloseDoors closingDoors;
    public static CloseDoors ClosingDoors
    {
        get
        {
            if (closingDoors == null)
                closingDoors = FindObjectOfType<CloseDoors>();

            return closingDoors;
        }
    }

    private bool doorToggle = true;
    public GameObject[] doors;

    private void Awake()
    {
        ReloadDoors();
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
        if (doors.Length == 0)
        {
            ReloadDoors();
        }

        foreach (GameObject door in doors)
        {
            door.SetActive(active);
        }
        Debug.Log("Deur " + doors.Length);
    }

    public void ReloadDoors()
    {
        doors = GameObject.FindGameObjectsWithTag("Door");
    }
}
