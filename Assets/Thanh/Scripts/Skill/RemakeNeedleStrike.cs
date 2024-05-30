using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemakeNeedleStrike : MonoBehaviour
{
    public float speed;
    public GameObject needle;
    public float radius;
    public float numberOfNeedle;
    public float degree = 360f;
    public float direction = 1;
    public float needleDamage = 5;

    //public float nextSpawnTime;
    //private float spawnTimer;
    PlayerHealth playerHealth;
    PlayerPointer playerPointer;
    EnemyHealth enemyHealth;
    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        playerPointer = FindObjectOfType<PlayerPointer>();
        enemyHealth = FindObjectOfType<EnemyHealth> ();

        //BoxCollider2D bc;
        //bc = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
    }
    private void Update()
    {
        //spawnTimer -= Time.deltaTime;
        if (playerHealth.isHurt == true && playerPointer.needleStrike == true)
        {
            SpawnNeedle();
            //spawnTimer = nextSpawnTime;
        }
    }

    void SpawnNeedle()
    {
        float arcLength = (degree / 360) * 2 * Mathf.PI;
        float angle = 0;
        float nextAngle = arcLength / numberOfNeedle;
        for(int i = 0; i < numberOfNeedle; i++) 
        {
            float x = Mathf.Cos(angle) * radius * direction;
            float y = Mathf.Sin(angle) * radius * direction;
            var obj = Instantiate(needle, transform.position, Quaternion.identity);
            var rb = obj.AddComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.velocity = new Vector2 (x, y) * speed;
            angle += nextAngle;
            float destroyTimer = 2;
            Destroy(obj, destroyTimer);
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.layer == 7)
    //    {
    //        enemyHealth.currentHealth -= needleDamage;
    //        Destroy(collision.gameObject);
    //    }
    //}
}
