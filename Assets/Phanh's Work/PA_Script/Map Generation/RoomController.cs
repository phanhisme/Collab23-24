using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomInfo
{
    //room information
    public string name;

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

    Room currRoom;

    //always load rooms in order
    Queue<RoomInfo> loadRoomQueue = new Queue<RoomInfo>();

    public List<Room> loadRooms = new List<Room>();

    //check if all the rooms are loaded
    bool isLoadingRoom = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //Load room 4 sides
        //LoadRoom("Start", 0, 0);
        //LoadRoom("Empty", 1, 0);
        //LoadRoom("Empty", -1, 0);
        //LoadRoom("Empty", 0, 1);
        //LoadRoom("Empty", 0, -1);
    }

    private void Update()
    {
        UpdateRoomQueue();
    }

    void UpdateRoomQueue()
    {
        if (isLoadingRoom)
        {
            return;
        }
        if (loadRoomQueue.Count == 0)
        {
            return; //there is nothing in the queue
        }

        currentLoadRoomData = loadRoomQueue.Dequeue();
        isLoadingRoom = true;

        StartCoroutine(LoadRoomRoutine(currentLoadRoomData));
    }

    //loding scenes
    public void LoadRoom (string name, int x, int y) //x,y coordinates
    {
        if (DoesRoomExist(x, y))
        {
            return;
        }

        //data for the new scene
        RoomInfo newRoomData = new RoomInfo(); //assign as new room
        newRoomData.name = name;
        newRoomData.X = x;
        newRoomData.Y = y;

        loadRoomQueue.Enqueue(newRoomData);
    }

    //delay load room to prevent multiple rooms load at once
    IEnumerator LoadRoomRoutine(RoomInfo info)
    {
        string roomName = currentWorldName + info.name;

        AsyncOperation loadRoom = SceneManager.LoadSceneAsync(roomName, LoadSceneMode.Additive); //spawn multiple scenes at once

        while (loadRoom.isDone == false)
        {
            yield return null;
        }
    }

    public void RegisterRoom(Room room)
    {
        if (!DoesRoomExist(currentLoadRoomData.X, currentLoadRoomData.Y))
        {
            //make sure they do not spawn on top of each other
            room.transform.position = new Vector3(currentLoadRoomData.X * room.Width, currentLoadRoomData.Y * room.Height, 0);

            room.X = currentLoadRoomData.X;
            room.Y = currentLoadRoomData.Y;
            room.name = currentLoadRoomData.name + " _ " + room.X + ", " + room.Y; //display name and coordinates

            room.transform.parent = transform;

            isLoadingRoom = false;

            if (loadRooms.Count == 0) //if there is no room loaded
            {
                CameraController.instance.currentRoom = room; //set current room to this room
            }

            loadRooms.Add(room);
        }
        else
        {
            Destroy(room.gameObject);
            isLoadingRoom = false;
        }
    }

    //check if the room exist by checking the coordinates
    public bool DoesRoomExist(int X, int Y)
    {
        return loadRooms.Find(item => item.X == X && item.Y == Y) != null;
    }

    public void OnPlayerEnterRoom(Room room)
    {
        //get the current room -> set the camera to that room
        CameraController.instance.currentRoom = room;
        currRoom = room;
    }
}
