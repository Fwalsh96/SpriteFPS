using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainMenuPanel;

    // New Game Button
    public void NewGameButton() {
        Debug.Log("Main Menu Button Pressed");
    }

    // Load Game Button
    public void LoadGameButton() {
        Debug.Log("Load Game Button Pressed");
    }

    // Options Button
    public void OptionsButton() {
        mainMenuPanel.SetActive(false);
    }

    // THIS BUTTON IS NOT WORKING
    // Exit to Desktop
    public void ExitGameButton() {
        // Consider adding are you sure
        Application.Quit();
    }

    // Demo Room Button
    public void ActivateDemoRoom() {

        SceneManager.LoadScene("Moving Room Objects");
    }

    // Back Button on options screen
    public void BackButton() {
        mainMenuPanel.SetActive(true);
    }
}
