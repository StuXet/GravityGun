using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        //Pause menu appears or gone when "esc" button was clicked
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }    
    }

    /*Resume to the game, lock the cursor to not be visible and to not be able to click on things in the game and desktop
    Set pause menu ui and bool variable to false
    Set game timescale to 1f to be able to game*/
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    /*Pause the game, unlock the cursor to be visible and to be able to click on things in the game
    Set pause menu ui and bool variable to true
    Set game timescale to 0f to pause the game*/
    void Pause()
    {
        Cursor.lockState = CursorLockMode.Confined;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    //Load the current scene again
    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    //Quit the game to desktop
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
    
}
