using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartStage : MonoBehaviour
{
    private bool wantToStart = false;

    public GameObject panel;


    private void Update()
    {
        if (wantToStart)
        {
            wantToStart = false;
            SceneManager.LoadScene("Base");
            GameObject player = FindObjectOfType<PlayerPointer>().gameObject;
            player.transform.position = new Vector2(0, 0);
            //ask the player if they want to start
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            wantToStart = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        wantToStart = false;
    }

    public void AcceptStage()
    {
        SceneManager.LoadScene("Base");
    }

    public void DeclineStage()
    {
        //turn off panel
        panel.SetActive(false);
    }

}
