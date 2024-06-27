using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public Animator pauseMenuAnimator;
    public GameObject pauseMenuAnim;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle the pause menu
            bool isActive = pauseMenuAnim.activeSelf;
            pauseMenuAnim.SetActive(!isActive);

            //// Play the animation if the pause menu is now active
            //if (!isActive)
            //{
            //    pauseMenuAnimator.Play("PauseAnimasd"); // Replace "YourAnimationName" with the name of your animation
            //}
        }
    }

    [SerializeField] GameObject pauseMenu;
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenuTrue");
    }
}

