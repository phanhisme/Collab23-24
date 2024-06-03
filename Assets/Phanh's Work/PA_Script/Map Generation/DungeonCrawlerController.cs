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

        for (int i = 0; i < dungeonData.minNumberOfCrawlers; i++)
        {
            dungeonCrawlers.Add(new DungeonCrawler(Vector2Int.zero));
        }

        int interation = Random.Range(dungeonData.interationMin, dungeonData.interationMax);

        for(int i = 0; i < interation; i++)
        {
            foreach (DungeonCrawler dungeonCrawler in dungeonCrawlers)
            {
                if (i == 0)
                {
                    lastDirection = dungeonCrawler.GetFirstDirection(directionMovementMap);

                    Vector2Int newPos = dungeonCrawler.MoveAtRandom(lastDirection, directionMovementMap);
                    positionsVisited.Add(newPos);
                }
                else
                {
                    Direction avoiding = dungeonCrawler.GetPathToAvoid(lastDirection);
                    Debug.Log("Last direction is: " + lastDirection + ". Thus, avoiding " + avoiding);

                    //get new lastDir
                    lastDirection = dungeonCrawler.GetNewDirection(directionMovementMap, avoiding);
                    Debug.Log("Getting new last direction: " + lastDirection);

                    Vector2Int newPos = dungeonCrawler.Move(directionMovementMap, lastDirection);
                    positionsVisited.Add(newPos);
                }
            }

            //if (dungeonCrawlers.Count == 0)
            //{
            //    Vector2Int newPos = dungeonCrawlers[0].Move(directionMovementMap);
            //    positionsVisited.Add(newPos);
            //}
            //else
            //{
            //    foreach (DungeonCrawler dungeonCrawler in dungeonCrawlers)
            //    {
            //        Vector2Int newPos = dungeonCrawler.Move(directionMovementMap);
            //        positionsVisited.Add(newPos);
            //    }
            //}
        }

        return positionsVisited;
    }
}
