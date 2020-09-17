using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Main Menu Button
    // Load Game Button
    // Options Button
    // Exit to Desktop
    // Demo Room Button
    public void ActivateDemoRoom() {

        SceneManager.LoadScene("Moving Room Objects");
    }
}
