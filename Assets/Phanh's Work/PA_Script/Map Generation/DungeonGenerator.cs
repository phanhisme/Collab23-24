using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public DungeonGenerationData dungeonGenerationData;
    private List<Vector2Int> dungeonRooms;

    private void Start()
    {
        dungeonRooms = DungeonCrawlerController.GenerateDungeon(dungeonGenerationData);
        SpawnRooms(dungeonRooms);
    }

    private void SpawnRooms(IEnumerable<Vector2Int> rooms)
    {
        //spawn start room at 0,0
        //keep outside to avoid spawning more than 1 start room
        RoomController.instance.LoadRoom("Start", 0, 0);

        int rand = Random.Range(3, dungeonRooms.Count - 1);
        Debug.Log("A special room is spawning at " + rand);

        foreach (Vector2Int roomLocation in rooms)
        {
            if (roomLocation == dungeonRooms[rand]) //one room only
            {
                RoomController.instance.LoadRoom("TreasureRoom", roomLocation.x, roomLocation.y);
            }

            //randomize between set rooms
            RoomController.instance.LoadRoom(RoomController.instance.GetRandomRoomName(), roomLocation.x, roomLocation.y);

            //this calls empty only - no enemies nor pick ups
            //RoomController.instance.LoadRoom("Empty", roomLocation.x, roomLocation.y);
        }
    }
}
