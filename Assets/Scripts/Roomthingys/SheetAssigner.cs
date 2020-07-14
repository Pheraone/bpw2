using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetAssigner : MonoBehaviour
{
    [SerializeField]
    Texture2D[] sheetsNormal;

    [SerializeField]
    GameObject RoomObj;

    public Vector2 roomDimensions = new Vector2(16 * 17, 16 * 19);
    public Vector2 gutterSize = new Vector2(16 * 9, 16 * 4);

    public void Assign(Chamber[,] chambers)
    {
        foreach(Chamber chamber in chambers)
        {
            if (chamber == null)
            {
                continue;
            }
            int index = Mathf.RoundToInt(Random.value * (sheetsNormal.Length - 1));
            Vector3 position = new Vector3(chamber.gridPosition.x * (roomDimensions.x + gutterSize.x), chamber.gridPosition.y * (roomDimensions.y + gutterSize.y), 0);
            ChamberInstance myChamber = Instantiate(RoomObj, position, Quaternion.identity).GetComponent<ChamberInstance>();
            myChamber.Setup(sheetsNormal[index], chamber.gridPosition, chamber.type, chamber.doorTop, chamber.doorBot, chamber.doorLeft, chamber.doorRight);
        }
    }
}
