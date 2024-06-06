using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour, IEnemyMovable
{
    public Rigidbody2D rb2d { get; set; }
    public bool IsFacingRight { get; set; } = true;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void CheckForLeftOrRightFacing(Vector2 velocity)
    {
        if(IsFacingRight && velocity.x < 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
        }
        if(IsFacingRight && velocity.x > 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
        }
    }

    public void MoveEnemy(Vector2 velocity)
    {
        rb2d.velocity = velocity;
        CheckForLeftOrRightFacing(velocity);
    }
    private void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {

    }
    public enum AnimationTriggerType
    { EnemyDamaged, PlayFootstepsAudio}

}
