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

    //update doors
    private bool updatedDoors = false;

    //override value for Room Controllers
    public Room(int x, int y)
    {
        X = x;
        Y = y;
    }

    //doors
    public Door leftDoor;
    public Door rightDoor;
    public Door topDoor;
    public Door bottomDoor;

    //door list
    public List<Door> doors = new List<Door>();

    void Start()
    {
        //if there is no room controller gameobject in the scene -> pressed play in the wrong scene, return
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
                    rightDoor = d;
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

    private void Update()
    {
        //if name of this object = "End" 
        if (name.Contains("End") && !updatedDoors)
        {
            //only remove the doors once!
            CreateDoorway();
            updatedDoors = true;
        }

    }

    public void CreateDoorway()
    {
        foreach (Door door in doors)
        {
            switch (door.doorType)
            {
                case Door.DoorType.right:
                    if (GetRight() != null)
                        DoorSetUp(door);
                    break;

                case Door.DoorType.left:
                    if (GetLeft() != null)
                        DoorSetUp(door);
                    break;

                case Door.DoorType.top:
                    if (GetTop() != null)
                        DoorSetUp(door);
                    break;

                case Door.DoorType.bottom:
                    if (GetBottom() != null)
                        DoorSetUp(door);
                    break;
            }
        }
    }

    //check if room exist, if not => delete the door
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
        if (RoomController.instance.DoesRoomExist(X - 1, Y))
        {
            return RoomController.instance.FindRoom(X - 1, Y);
        }

        return null;
    }
    
    public Room GetTop()
    {
        if (RoomController.instance.DoesRoomExist(X, Y + 1))
        {
            return RoomController.instance.FindRoom(X, Y + 1);
        }

        return null;
    }
    
    public Room GetBottom()
    {
        if (RoomController.instance.DoesRoomExist(X, Y - 1))
        {
            return RoomController.instance.FindRoom(X, Y - 1);
        }

        return null;
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
        if (collision.gameObject.tag == "Player")
        {
            //call room controller to call for the camera
            RoomController.instance.OnPlayerEnterRoom(this);
            Debug.Log("entering new room");
        }
    }

    public void DoorSetUp(Door thisDoor)
    {
        //remove collider
        BoxCollider2D rightCol = thisDoor.gameObject.GetComponent<BoxCollider2D>();
        rightCol.enabled = false;

        //change color
        SpriteRenderer sprite = thisDoor.gameObject.GetComponent<SpriteRenderer>();
        sprite.color = Color.blue;
    }
}
