using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{

    Vector2 worldSize = new Vector2(4, 4);
    Chamber[,] chambers;
    List<Vector2> takenPositions = new List<Vector2>();
    int gridSizeX, gridSizeY;
    public int numberOfChambers = 20;
    public GameObject GenerationRoomObject;

    void Start()
    {
        //math for generation
        if(numberOfChambers >= (worldSize.x * 2) * (worldSize.y * 2))
        {
            numberOfChambers = Mathf.RoundToInt((worldSize.x * 2) * (worldSize.y * 2));
        }
        gridSizeX = Mathf.RoundToInt(worldSize.x);
        gridSizeY = Mathf.RoundToInt(worldSize.y);

        CreateChambers();

       
    }

    private void Update()
    {
        if ( Input.GetKeyDown(KeyCode.R) )
        {
            //fix might be emptying the list here
            //List not yet empty here after regenerating the dungeon... needs fix, this is gamebreaking.
            //Debug.Log("Doors is : " + CloseDoors.Instance.doors);
            //CloseDoors.ClosingDoors.ReloadDoors();
            CreateChambers();
        }
    }

    public void CreateChambers()
    {
        Debug.Log("I do something");

        //checks if rooms are in the array
        if ( chambers != null )
        {
            //set player pos back to 0.0
            PlayerMovement.Instance.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
            GameObject[] currentChambers = GameObject.FindGameObjectsWithTag("Chamber");
            //destroy all existing chambers
            foreach ( GameObject thisChamber in currentChambers )
            {
                Destroy(thisChamber);
            }
            CloseDoors.ClosingDoors.ReloadDoors();
            takenPositions = new List<Vector2>();
        }

        //setup
        chambers = new Chamber[gridSizeX * 2, gridSizeX * 2];
        //starting point at the center of the scene, type 1
        chambers[gridSizeX, gridSizeY] = new Chamber(Vector2.zero, 1);
        takenPositions.Insert(0, Vector2.zero);
        Vector2 checkPosition = Vector2.zero;

        float randomCompare = 0.2f;
        float randomCompareBegin = 0.2f;
        float randomCompareEnd = 0.1f;

        //loop for rooms
        for(int i = 0; i < numberOfChambers -1; i++)
        {
           
            float randomPerc = ((float)i) / (((float)numberOfChambers - 1));
            //magic numbers? 
            randomCompare = Mathf.Lerp(randomCompareBegin, randomCompareEnd, randomPerc);
            //get new position
            checkPosition = NewPosition();
            //test new position //more interesting shapes | change this to change whole shape dungeon
            if(NumberOfNeighbours(checkPosition, takenPositions) > 1 && Random.value > randomCompare)
            {
                int iterations = 0;
                do
                {
                    checkPosition = SelectiveNewPosition();
                    iterations++;
                } while (NumberOfNeighbours(checkPosition, takenPositions) > 1 && iterations < 100);
                if(iterations >= 50)
                { 
                    Debug.Log("Can not create with fewer neighbours than : " + NumberOfNeighbours(checkPosition, takenPositions));
                }

            }                //finalize position

            chambers[(int)checkPosition.x + gridSizeX, (int)checkPosition.y + gridSizeY] = new Chamber(checkPosition, 0);
            takenPositions.Insert(0, checkPosition);
        }

        Debug.Log("hre");

        SetChamberDoors();
        DrawMap();
        GetComponent<SheetAssigner>().Assign(chambers);

        CloseDoors.ClosingDoors.ReloadDoors();
    }

    Vector2 NewPosition()
    {
        int x = 0;
        int y = 0;
        Vector2 checkingPosition = Vector2.zero;

        do
        {
            //take randomly selected position from list
            int index = Mathf.RoundToInt(Random.value * (takenPositions.Count - 1));
            x = (int)takenPositions[index].x;
            y = (int)takenPositions[index].y;

            //up? down? left? right?
            bool UpDown = (Random.value < 0.5f);
            bool positive = (Random.value < 0.5f);

            if (UpDown)
            {
                if (positive)
                {
                    y += 1;
                }
                else
                {
                    y -= 1;
                }
            }
            else
            {
                if (positive)
                {
                    x += 1;
                }
                else
                {
                    x -= 1;
                }
            }
            //go through loop till free position is found within grid
            checkingPosition = new Vector2(x, y);
        } while(takenPositions.Contains(checkingPosition) || x >= gridSizeX || x <= -gridSizeX || y >= gridSizeY || y <= -gridSizeY);

        return checkingPosition;
    }

    //gets chamber with 1 neighbour for extra brancing effect
    Vector2 SelectiveNewPosition()
    {
        //Ugly if's, need to change this if I can
        int index = 0;
        int inc;
        int x = 0;
        int y = 0;
        Vector2 checkingPosition = Vector2.zero;

        do
        {
            inc = 0;
            do
            {
                //take randomly selected position from list
                index = Mathf.RoundToInt(Random.value * (takenPositions.Count - 1));
                inc++;
            } while (NumberOfNeighbours(takenPositions[index], takenPositions) > 1 && inc < 100);

            x = (int)takenPositions[index].x;
            y = (int)takenPositions[index].y;

            //up? down? left? right?
            bool upDown = (Random.value < 0.5f);
            bool positive = (Random.value < 0.5f);

            if (upDown)
            {
                if (positive)
                {
                    y += 1;
                }
                else
                {
                    y -= 1;
                }
            }
            else
            {
                if (positive)
                {
                    x += 1;
                }
                else
                {
                    x -= 1;
                }
            }

            //go through loop till free position is found within grid
            checkingPosition = new Vector2(x, y);
        } while (takenPositions.Contains(checkingPosition) || x >= gridSizeX || x <= -gridSizeX || y >= gridSizeY || y <= -gridSizeY);

        if (inc >= 100)
        {
            Debug.Log("Error: could not find position with only 1 neighbour");
        }

        return checkingPosition;
    }

    int NumberOfNeighbours(Vector2 checkingPosition, List<Vector2> usedPositions)
    {
        int ret = 0;
        //question: does this do the same as...
        if(usedPositions.Contains(checkingPosition + Vector2.right))
        {
            ret++;
        }
        if (usedPositions.Contains(checkingPosition + Vector2.left))
        {
            ret++;
        }
        if (usedPositions.Contains(checkingPosition + Vector2.up))
        {
            ret++;
        }
        if (usedPositions.Contains(checkingPosition + Vector2.down))
        {
            ret++;
        }
        return ret;

    }

    public void DrawMap()
    {

        foreach (Chamber chamber in chambers)
        {
            Debug.Log(chamber);
            if (chamber == null)
            {
                continue;
            }

            Vector2 drawPosition = chamber.gridPosition;
            drawPosition.x *= 16;
            drawPosition.y *= 8;


            MapSpriteSelector mapper = Object.Instantiate(GenerationRoomObject, drawPosition, Quaternion.identity).GetComponent<MapSpriteSelector>();
            Debug.Log("new obj" + chamber);


            //set equal to other script
            mapper.type = chamber.type;
            mapper.up = chamber.doorTop;
            mapper.down = chamber.doorBot;
            mapper.right = chamber.doorRight;
            mapper.left = chamber.doorLeft;

        }
    }


    public void SetChamberDoors()
    {
        for(int x = 0; x< ((gridSizeX * 2)); x++)
        {
            for(int y = 0; y < ((gridSizeY * 2)); y++)
            {
                if (chambers[x,y] == null)
                {
                    continue;
                }

                Vector2 gridPosition = new Vector2(x, y);

                if (y - 1< 0)
                {
                    chambers[x, y].doorBot = false;
                } 
                else
                {
                    chambers[x, y].doorBot = (chambers[x, y - 1] != null);
                }

                if (y + 1 >= gridSizeY * 2)
                {
                    chambers[x, y].doorTop = false;
                } 
                else
                {
                    chambers[x, y].doorTop = (chambers[x, y + 1] != null);
                }

                if (x - 1 < 0)
                {
                    chambers[x, y].doorLeft = false;
                }
                else
                {
                    chambers[x, y].doorLeft = (chambers[x - 1, y] != null);
                }
                if (x + 1 >= gridSizeX * 2)
                {
                    chambers[x, y].doorRight = false;
                }
                else
                {
                    chambers[x, y].doorRight = (chambers[x + 1, y] != null);
                }
            }
        }
    }
}
