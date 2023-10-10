using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomInfo
{
    //room information
    public string roomName;

    //room coordinates
    public int X;
    public int Y;
}

public class RoomController : MonoBehaviour
{
    //create instance for singleton
    public static RoomController instance;

    //name of the current world
    string currentWorldName = "Base";
    
    RoomInfo currentLoadRoomData;

    //always load rooms in order
    Queue<RoomInfo> loadRoomQueue = new Queue<RoomInfo>();

    public List<Room> loadRooms = new List<Room>();

    private void Awake()
    {
        instance = this;
    }

    //check if the room exist by checking the coordinates
    public bool DoesRoomExist(int X, int Y)
    {
        return loadRooms.Find(item => item.X == x && item.Y == y) != null;
    }
}
