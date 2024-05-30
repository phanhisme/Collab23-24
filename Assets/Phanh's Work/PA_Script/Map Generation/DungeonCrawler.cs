using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCrawler : MonoBehaviour
{
    public Vector2Int position { get; set; }

    public DungeonCrawler(Vector2Int startPos)
    {
        position = startPos;
    }

    public Vector2Int Move(Dictionary<Direction,Vector2Int> directionMovementMap)
    {
        Dictionary<Direction, Vector2Int> lastDir = GetLastDirection(directionMovementMap);
        Debug.Log(lastDir);
        switch (lastDir)
        {
            //case directionMovementMap[0]:
            //    break;
        }
        Direction toMove = (Direction)Random.Range(0, directionMovementMap.Count);
        position += directionMovementMap[toMove];
        return position;
    }

    public Dictionary<Direction, Vector2Int> GetLastDirection(Dictionary<Direction, Vector2Int> dir)
    {
        return dir;
    }
}
