using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]

//public class Loot
//{
//    public GameObject items;
//    [Range(0.01f, 100f)]

//    public float dropRate;
//    public int minQuantity;
//    public int maxQuantity;
//}
//public class ItemsDrop : MonoBehaviour
//{

//    // Start is called before the first frame update
//    public Loot[] loots;

//    public void DropItem()
//    {
//        foreach (Loot loot in loots)
//        {
//            float spawnChance = Random.Range(-0.01f, 100f);
//            if (spawnChance <= loot.dropRate)
//            {
//                int spawnAmount = Random.Range(loot.minQuantity, loot.maxQuantity);
//                for (int i = 0; i < spawnAmount; i++)
//                {
//                    GameObject currentDrop = Instantiate(loot.items, transform.position, transform.rotation * Quaternion.Euler(new Vector3(0, 0, Random.Range(transform.rotation.y - 40, transform.rotation.y + 40))));
//                    //currentDrop.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, 10), ForceMode2D.Impulse);
//                }
//            }
//        }
//    }
//}

public class ItemDrop : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float value;
    public RewardType rewardType;
    
    public void SetData(RewardType rewardType, float value)
    {
        this.value = value;
        this.rewardType = rewardType;
    }
}