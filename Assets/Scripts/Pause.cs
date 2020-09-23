using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;      // for changing scenes.

public class Pause : MonoBehaviour
{
    bool gameIsPaused = false;

    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        if(pauseMenu != null) {                 // if the pauseMenu exists
            pauseMenu.SetActive(false);         // turn it off.
        } else {
            GameObject.Find("PauseMenu");       // if it DOESN'T exist, try to find it.
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            PauseGame();
        }
    }

    public void PauseGame() {
        // is the game already paused? 
        if(gameIsPaused) {
            // then unPause it.
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        } else {
            // otherwise, pause the game.
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }

        // finally, flip the gameIsPaused boolean.
        gameIsPaused = !gameIsPaused;
    }

    public void SwitchScene(int givenSceneIndex) {
        SceneManager.LoadScene(givenSceneIndex);
        // make sure game is "unpaused"
        Time.timeScale = 1;
    }

    public void QuitGame() {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
