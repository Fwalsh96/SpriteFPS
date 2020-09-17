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

    // Function that resumes the game
    public void resumeGame()
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

    // Function that pauses the game
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

    // Function that exits the game
    public void quitGame() {
        Debug.Log("Quit Game pressed");
    }

    // Function that returns player to the main menu
    public void returnToMenu() {
        Debug.Log("Main Menu pressed");
    }

    // Function that loads the options menu
    public void optionsMenu() {
        Debug.Log("Options menu pressed");
    }

    // Enable or disable the player controls
    private void DisableMouseLook(bool enable, Player user) {

        user.transform.GetComponent<Player>().enabled = enable;
    }
}
