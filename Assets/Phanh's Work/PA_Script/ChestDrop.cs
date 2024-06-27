using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Loot
{
    public GameObject items;
    [Range(0.01f, 100f)]

    public float dropRate;
    public int minQuantity;
    public int maxQuantity;
}

public class ChestDrop : MonoBehaviour
{
    // Start is called before the first frame update
    public Loot[] loots;
    private bool isInRange = false;
    bool dropped = false;

    private void Update()
    {
        if (isInRange && !dropped)
        {
            dropped = true;
            DropItem();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interactable")
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
    }

    public void DropItem()
    {
        foreach (Loot loot in loots)
        {
            float spawnChance = Random.Range(-0.01f, 100f);
            if (spawnChance <= loot.dropRate)
            {
                int spawnAmount = Random.Range(loot.minQuantity, loot.maxQuantity);
                for (int i = 0; i < spawnAmount; i++)
                {
                    GameObject currentDrop = Instantiate(loot.items, transform.position, transform.rotation * Quaternion.Euler(new Vector3(0, 0, Random.Range(transform.rotation.y - 40, transform.rotation.y + 40))));
                    currentDrop.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, 0.5f), ForceMode2D.Impulse);
                }
            }
        }
    }
}


