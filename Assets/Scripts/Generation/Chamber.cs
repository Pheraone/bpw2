using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chamber
{
    public Vector2 gridPosition;
    //If more make string array?
    public int type;
    public bool doorTop, doorBot, doorLeft, doorRight;

    public Chamber(Vector2 gridPosition, int type)
    {
        this.gridPosition = gridPosition;
        this.type = type;
    }
}
