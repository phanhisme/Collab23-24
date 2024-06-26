using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetCoin : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        //check if the game object is a coin
        if(collision.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            //find player's location
            coin.FindTarget(transform.parent.position);
        }

        else if (collision.gameObject.TryGetComponent<UniversalPickUps>(out UniversalPickUps item))
        {
            item.FindTarget(transform.parent.position);
        }
    }
}
