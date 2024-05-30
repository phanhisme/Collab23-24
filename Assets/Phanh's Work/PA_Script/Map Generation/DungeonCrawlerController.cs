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

        //for (int i = 0; i < crawlers; i++) //if crawlers is 2, interation should take note too
        //{
        //    dungeonCrawlers.Add(new DungeonCrawler(Vector2Int.zero));
        //}

        int interation = Random.Range(dungeonData.interationMin, dungeonData.interationMax);
        Debug.Log("Interation begin with " + interation);
        for(int i = 0; i < interation; i++)
        {
            //check for chance of max crawlers
            int r = numberOfCrawlers(dungeonData);
            if (r == dungeonData.minNumberOfCrawlers)
            {
                
            }
            else if (r == dungeonData.maxNumberOfCrawlers)
            {
                for(int t = 0; t < r; t++)
                {
                    Debug.Log("Start index is: " + i);
                    i += 1;
                    Debug.Log("Late index is: " + i);
                }
            }

            foreach (DungeonCrawler dungeonCrawler in dungeonCrawlers)
            {
                if (i == 0)
                {
                    dungeonCrawlers.Add(new DungeonCrawler(Vector2Int.zero));
                    lastDirection = dungeonCrawler.GetFirstDirection(directionMovementMap);

                    Vector2Int newPos = dungeonCrawler.MoveAtRandom(lastDirection, directionMovementMap);
                    positionsVisited.Add(newPos);
                }
                else if (i > 0 && i < interation)
                {
                    Direction avoiding = dungeonCrawler.GetPathToAvoid(lastDirection);
                    Debug.Log("Last direction is: " + lastDirection + ". Thus, avoiding " + avoiding);

                    //get new lastDir
                    lastDirection = dungeonCrawler.GetNewDirection(directionMovementMap, avoiding);
                    Debug.Log("Getting new last direction: " + lastDirection);

                    Vector2Int newPos = dungeonCrawler.Move(directionMovementMap, lastDirection);
                    positionsVisited.Add(newPos);
                }
                else if (i == interation)
                {
                    Debug.Log("This is the end other loop. Total index is " + i);
                }
            }
        }

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
