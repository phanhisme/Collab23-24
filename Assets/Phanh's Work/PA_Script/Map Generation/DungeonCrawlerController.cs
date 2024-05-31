using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    up = 0,
    left = 1,
    down = 2,
    right = 3
};

public class DungeonCrawlerController : MonoBehaviour
{
    public static Direction lastDirection;

    public static List<Vector2Int> positionsVisited = new List<Vector2Int>();
    private static readonly Dictionary<Direction, Vector2Int> directionMovementMap = new Dictionary<Direction, Vector2Int>
    {   
        {Direction.up,Vector2Int.up },
        {Direction.left,Vector2Int.left },
        {Direction.down,Vector2Int.down },
        {Direction.right,Vector2Int.right },
    };

    public static List<Vector2Int> GenerateDungeon(DungeonGenerationData dungeonData)
    {
        List<DungeonCrawler> dungeonCrawlers = new List<DungeonCrawler>();
        List<DungeonCrawler> containStuff = new List<DungeonCrawler>();

        //for (int i = 0; i < crawlers; i++) //if crawlers is 2, interation should take note too
        //{
        //    dungeonCrawlers.Add(new DungeonCrawler(Vector2Int.zero));
        //}

        int interation = Random.Range(dungeonData.interationMin, dungeonData.interationMax);
        Debug.Log("Interation begin with " + interation);

        do
        {
            int roomsToSpawn;
            if (positionsVisited.Count == 0)
            {
                dungeonCrawlers.Add(new DungeonCrawler(Vector2Int.zero));
                roomsToSpawn = 1;
            }
            else
            {
                //check for chance of max crawlers
                int r = numberOfCrawlers(dungeonData);

                for (int a = 0; a < r; a++) //if crawlers is 2, spawn 2 rooms
                {
                    //add new crawler from the position of the last position visited
                    dungeonCrawlers.Add(new DungeonCrawler(positionsVisited[positionsVisited.Count - 1]));

                    Debug.Log(positionsVisited[positionsVisited.Count - 1] +"has travelled from"+ lastDirection);
                }

                roomsToSpawn = r;
                for (int n = roomsToSpawn; n > 0; n--)
                {
                    foreach (DungeonCrawler dungeonCrawler in dungeonCrawlers)
                    {
                        Debug.Log("Since number of room is " + roomsToSpawn + ", left with" + n + " rooms");

                        if (positionsVisited.Count == 0)
                        {
                            lastDirection = dungeonCrawler.GetFirstDirection(directionMovementMap);

                            Vector2Int newPos = dungeonCrawler.MoveAtRandom(lastDirection, directionMovementMap);
                            positionsVisited.Add(newPos);
                        }
                        else if (positionsVisited.Count > 0 && positionsVisited.Count < interation)
                        {
                            Direction avoiding = dungeonCrawler.GetPathToAvoid(lastDirection);

                            //get new lastDir
                            lastDirection = dungeonCrawler.GetNewDirection(directionMovementMap, avoiding);
                            Debug.Log("moving to " + lastDirection);

                            Vector2Int newPos = dungeonCrawler.Move(directionMovementMap, lastDirection);
                            positionsVisited.Add(newPos);
                        }

                        containStuff.Add(dungeonCrawler);
                        Debug.Log("Contain " + dungeonCrawler + "similar with " + containStuff[containStuff.Count - 1]);
                        dungeonCrawlers.Remove(dungeonCrawler);

                    }
                }
            }

        } while (positionsVisited.Count != interation);

        

        return positionsVisited;
    }

    public static int numberOfCrawlers(DungeonGenerationData dungeonData) //chance to spawn 1/2 room (following data of the S0 dungeonData)
    {
        int crawlers;
        float rCrawlers = Random.value;
        if (rCrawlers < 0.2f)
        {
            crawlers = dungeonData.maxNumberOfCrawlers;
        }
        else
            crawlers = dungeonData.minNumberOfCrawlers; //percent to have 2 route is lower to lower chance of meeting the boss early
        return crawlers;
    }
}
