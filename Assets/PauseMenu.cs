using SpriteFPS.General;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{

    public static bool isPaused = false;
    public Player player;
    public UnityEngine.UI.Image menu;

    void Update() {

        if (Input.GetKeyDown(player.pauseButton)) {

            Debug.Log("Pause Key was pressed");

            // Check to see if the game is paused
            if (isPaused == true) {

                resumeGame();
            }
            else {
                pauseGame();
            }
        }
    }

    void resumeGame() {

        menu.gameObject.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

    }

    void pauseGame() {

        menu.gameObject.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
      
    }
}
