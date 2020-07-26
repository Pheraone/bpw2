using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsBehaviour : MonoBehaviour
{
    //dit is een singleton
    private static DoorsBehaviour closingDoors;
    public static DoorsBehaviour ClosingDoors
    {
        get
        {
            if (closingDoors == null)
                closingDoors = FindObjectOfType<DoorsBehaviour>();

            return closingDoors;
        }
    }

    private bool doorToggle = true;
    public GameObject[] doors;

    public List<GameObject> doorsList;

    private void Awake()
    {
        ReloadDoors();
        doorsList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

      
    }

    public void ActivateDoors(bool active)
    {
       
        foreach (GameObject door in doorsList)
        {
            door.SetActive(active);
        }
    }
    public void ReloadDoors()
    {
        doors = GameObject.FindGameObjectsWithTag("Door");
        doorsList.Clear();

        Debug.Log("door list count: " + doorsList.Count);
        StartCoroutine("OneFrameReload");
    }

    public IEnumerator OneFrameReload()
    {
        yield return 0;

        doorsList.AddRange(GameObject.FindGameObjectsWithTag("Door"));
    }
}

