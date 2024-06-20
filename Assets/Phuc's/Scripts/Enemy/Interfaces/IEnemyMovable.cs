using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyMovable 
{
    Rigidbody2D rb2d { get; set; }
    bool IsFacingRight { get; set; }
    void MoveEnemy(Vector2 velocity);
    void CheckForLeftOrRightFacing(Vector2 velocity);
}