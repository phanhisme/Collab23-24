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

        RoomController.instance.RegisterRoom(this);
    }

    private void OnDrawGizmos()
    {
        //draw gizmos for the rooms
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(Width, Height, 0));
    }

    public Vector3 GetRoomCentre()
    {
        //calculates the center of the room
        return new Vector3(X * Width, Y * Height);
    }

    //when the player enter a new room
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //call room controller to call for the camera
            RoomController.instance.OnPlayerEnterRoom(this);
        }
    }
}
