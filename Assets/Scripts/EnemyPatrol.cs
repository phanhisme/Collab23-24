using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyPatrol : MonoBehaviour
{

    public GameObject player;
        

    public float speed;
    public float distance;
    public float detectionDistance;

    public bool hasDetectPlayer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //The distance between the enemy's pos to the player pos
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        //Prevent moving faster diagonally 
        direction.Normalize();

        //finding angles between 2 points and set the randians to degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


        /*If the player is in range of detection of the enemy
        then the enemy will move towards the player */
        if (distance < detectionDistance)
        {
            //If the enemy has detected the player then move 
            //towards the player
            hasDetectPlayer = true;
            if(hasDetectPlayer)
            {
                //Moving towards the player
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(Vector3.forward * angle);     //Returns a rotation on the z axis
            }
        }
        else
        {
            //The enemy cannot detect the player outside range
            hasDetectPlayer = false;
        }
    }
}
