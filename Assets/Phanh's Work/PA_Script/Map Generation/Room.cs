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

    //doors
    public Door leftDoor;
    public Door righttDoor;
    public Door topDoor;
    public Door bottomDoor;

    //door list
    public List<Door> doors = new List<Door>();

    void Start()
    {
        //if pressed play in the wrong scene, return
        if (RoomController.instance == null)
        {
            Debug.Log("You pressed play in the wrong scene!");
            return;
        }

        //ds = doors
        Door[] ds = GetComponentsInChildren<Door>();

        foreach(Door d in ds)
        {
            //adding every doors to the door list
            doors.Add(d);

            switch (d.doorType)
            {
                case Door.DoorType.right:
                    righttDoor = d;
                    break;

                case Door.DoorType.left:
                    leftDoor = d;
                    break;

                case Door.DoorType.top:
                    topDoor = d;
                    break;

                case Door.DoorType.bottom:
                    bottomDoor = d;
                    break;
            }
        }

        RoomController.instance.RegisterRoom(this);
    }

    public void RemoveUnconnectedDoor()
    {
        foreach (Door door in doors)
        {
            switch (door.doorType)
            {
                case Door.DoorType.right:
                    GetRight();
                    break;

                case Door.DoorType.left:
                    GetLeft();
                    break;

                case Door.DoorType.top:
                    GetTop();
                    break;

                case Door.DoorType.bottom:
                    GetBottom();
                    break;
            }
        }
    }

    public Room GetRight()
    {
        if (RoomController.instance.DoesRoomExist(X + 1, Y))
        {
            return RoomController.instance.FindRoom(X + 1, Y);
        }

        return null;
    }
    
    public Room GetLeft()
    {

    }
    
    public Room GetTop()
    {

    }
    
    public Room GetBottom()
    {

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
