using SpriteFPS.General;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public Player currentPlayer;

    void Update()
    {

        if (Input.GetKeyDown(currentPlayer.pauseButton))
        {

            Debug.Log("Pause Key was pressed");

            // Check to see if the game is paused
            if (isPaused)
            {

                resumeGame();
            }
            else
            {
                pauseGame();
            }
        }
    }

    void resumeGame()
    {
        // Deactivate the menu
        pauseMenuUI.SetActive(false);

        // Set the current state of the cursor to stay on the screen
        Cursor.lockState = CursorLockMode.Locked ;

        // Unpause time
        Time.timeScale = 1f;

        // Set the pause variable
        isPaused = false;

        // Enable the player's ability to move
        DisableMouseLook(true, currentPlayer);

    }

    void pauseGame()
    {
        // Load the menu
        pauseMenuUI.SetActive(true);

        // Set the current state of the cursor
        Cursor.lockState = CursorLockMode.None;

        // Pause Time
        Time.timeScale = 0f;

        // Set the pause variable
        isPaused = true;

        // Disable the player's ability to move in game
        DisableMouseLook(false, currentPlayer);

    }

    private void DisableMouseLook(bool enable, Player user) {



        user.transform.GetComponent<Player>().enabled = enable;
    }
}
