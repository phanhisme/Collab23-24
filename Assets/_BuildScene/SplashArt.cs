using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SplashArt : MonoBehaviour
{
    public float cutsceneDuration = 10f; // Duration of the cutscene in seconds
    public string mainMenuSceneName = "MainMenuTrue"; // Name of the main menu scene

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EndSplash());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator EndSplash()
    {
        // Wait for the cutscene to finish
        yield return new WaitForSeconds(cutsceneDuration);

        // Load the main menu scene
        SceneManager.LoadScene(mainMenuSceneName);
    }
}