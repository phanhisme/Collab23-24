using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public Room room;

    [System.Serializable]
    public struct Grid
    {
        public int col, row;
        public float verticalOffset, horizontalOffset;
    }

    public Grid grid;
    public GameObject gridTiles;
    public List<Vector2> availablePoints = new List<Vector2>();

    private void Awake()
    {
        //do not spawn too near with the wall of the room
        room = GetComponentInParent<Room>();
        grid.col = room.Width - 2;
        grid.row = room.Height - 2;
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        //get locations 
        grid.verticalOffset += room.transform.localPosition.y;
        grid.horizontalOffset += room.transform.localPosition.x;

        for(int y = 0; y < grid.row; y++)
        {
            for(int x = 0; x < grid.col; x++)
            {
                //spawn game objects
                GameObject gameObject = Instantiate(gridTiles, transform);
                gameObject.transform.position = new Vector2(x - (grid.col - grid.horizontalOffset), y - (grid.row - grid.verticalOffset));
                gameObject.name = "X: " + x + ", Y: " + y;
                availablePoints.Add(gameObject.transform.position);

                gameObject.SetActive(false);
            }
        }

        GetComponentInParent<ObjectRoomSpawner>().InitialiseObjectSpawning();
    }

}
