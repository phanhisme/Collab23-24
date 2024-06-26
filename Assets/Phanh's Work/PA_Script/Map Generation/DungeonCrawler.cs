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

    public Vector2Int MoveAtRandom(Direction toMove, Dictionary<Direction, Vector2Int> directionMovementMap)
    {
        position += directionMovementMap[toMove];

        return position;
    }

    public Direction GetFirstDirection(Dictionary<Direction, Vector2Int> directionMovementMap)
    {
        Direction toMove = (Direction)Random.Range(0, directionMovementMap.Count);
        Debug.Log("First direction is " + toMove);
        return toMove;
    }

    public Vector2Int Move(Dictionary<Direction, Vector2Int> directionMovementMap, Direction movingTo)
    {
        position += directionMovementMap[movingTo];
        return position;
    }

    public Direction GetNewDirection(Dictionary<Direction, Vector2Int> directionMovementMap, Direction avoiding)
    {
        Direction movingTo = NewDirection(avoiding, directionMovementMap);
        Debug.Log("Direction is moving to: " + movingTo);
        return movingTo;
    }

    public Direction GetPathToAvoid(Direction lastDir)
    {
        Direction directionToAvoid;
        //Find which direction to avoid
        switch (lastDir)
        {
            case Direction.down:
                directionToAvoid = Direction.up;
                break;

            case Direction.up:
                directionToAvoid = Direction.down;
                break;

            case Direction.right:
                directionToAvoid = Direction.left;
                break;

            case Direction.left:
                directionToAvoid = Direction.right;
                break;

            default:
                directionToAvoid = Direction.up;
                break;
        }
        return directionToAvoid;
    }

    public Direction NewDirection(Direction directionToAvoid, Dictionary<Direction, Vector2Int> directionMovementMap)
    {
        //loop until condition is satisfy
        Direction newDir;
        do
        {
            newDir = (Direction)Random.Range(0, directionMovementMap.Count);
        } while (newDir == directionToAvoid);

        //if found the path
        return newDir;
    }
}
