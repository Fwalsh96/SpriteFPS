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

        if (Input.GetKeyDown(KeyCode.Escape))
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
        pauseMenuUI.SetActive(false);
        //Cursor.lockState = CursorLockMode.Confined ;
        //Cursor.visible = false;
        //menu.gameObject.SetActive(false);
        //Time.timeScale = 1f;
        isPaused = false;
        DisableMouseLook(true, currentPlayer);

    }

    void pauseGame()
    {
        pauseMenuUI.SetActive(true);
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = true;
        //menu.gameObject.SetActive(true);
        //Time.timeScale = 0f;
        isPaused = true;
        DisableMouseLook(false, currentPlayer);

    }

    private void DisableMouseLook(bool enable, Player user) {



        user.transform.GetComponent<Player>().enabled = enable;
    }
}
