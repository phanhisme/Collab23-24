using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public Room room;

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
        room = GetComponentInParent<Room>();
        grid.col = room.Width;
    }
}
