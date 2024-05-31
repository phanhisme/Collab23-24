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
            //if (roomLocation == dungeonRooms[rand]) //one room only
            //{
            //    RoomController.instance.LoadRoom("TreasureRoom", roomLocation.x, roomLocation.y);
            //}
            RoomController.instance.LoadRoom("Empty", roomLocation.x, roomLocation.y);





            //spawn the start room at the first room to spawn
            //if (roomLocation == dungeonRooms[0])
            //{
            //    RoomController.instance.LoadRoom("Start", roomLocation.x, roomLocation.y);
            //}


            ////the room is the last to spawn and not at the start location (avoid overlapping with the start room)
            //if (roomLocation == dungeonRooms[dungeonRooms.Count - 1] && !(roomLocation == Vector2Int.zero))
            //{
            //    //load end room (not effective for the last room (sometimes it spawns next to the start room)
            //    //child the sprite of the room to the room object to make the mark (the mark default (outside of the parents) will have the centre as 0,0 -> start room location)
            //    //results in overlapping with the start room

            //    RoomController.instance.LoadRoom("End", roomLocation.x, roomLocation.y);
            //}
            //else
            //{
            //    //set location of the spawn room (random coordinates)
            //    RoomController.instance.LoadRoom("Empty", roomLocation.x, roomLocation.y);
            //}    
        }
    }
}
