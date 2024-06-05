using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenMoment : MonoBehaviour
{
    public float currentStackMoment;
    public float fullStackedMoment = 20;
    public bool isStacked;
    PlayerPointer player;
    EnemyHealth enemyHealth; 
    SpriteRenderer spriteRenderer;
    Color color;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<PlayerPointer>();
        enemyHealth = FindObjectOfType<EnemyHealth>();
        isStacked = false;
        currentStackMoment = 0;
        color = spriteRenderer.material.color;
    }

    private void Update()
    {
        if(player.startStackingGM == true)
        {
            GoldenMomentIsReady();
        }
    }
    void GoldenMomentIsReady()
    {
        StackingMoment();
        if (Input.GetKeyDown(KeyCode.Z) && isStacked == true)
        {
            StartCoroutine(Invulnerable());
            Debug.Log("Ready");
        }
    }

    void StackingMoment()
    {
        if(enemyHealth.isHit == true)
        {
            currentStackMoment++;
        }
        if(currentStackMoment ==  fullStackedMoment)
        {
            isStacked = true;
            currentStackMoment = 0;
        }
    }


    private IEnumerator Invulnerable()
    {
        Physics2D.IgnoreLayerCollision(3, 7, true);
        color.a = 0.5f;
        spriteRenderer.material.color = color;
        float InvulnerableTime = 2;
        yield return new WaitForSeconds(InvulnerableTime);
        Physics2D.IgnoreLayerCollision(3, 7, false);
        color.a = 1f;
        spriteRenderer.material.color = color;
        isStacked = false;
    }
}
