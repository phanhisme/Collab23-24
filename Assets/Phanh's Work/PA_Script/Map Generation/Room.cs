using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    //size of room
    public int Width;
    public int Height;

    //room coordinates
    public int X;
    public int Y;

    void Start()
    {
        //if pressed play in the wrong scene, return
        if (RoomController.instance == null)
        {
            Debug.Log("You pressed play in the wrong scene!");
            return;
        }
    }

    private void OnDrawGizmos()
    {
        //draw gizmos for the rooms
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(transform.position, new Vector3(Width, Height, 0));
    }

    public Vector3 GetRoomCentre()
    {
        //calculates the center of the room
        return new Vector3(X * Width, Y * Height);
    }
}
