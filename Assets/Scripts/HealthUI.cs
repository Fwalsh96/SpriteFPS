using SpriteFPS.General;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.WSA.Input;

public class HealthUI : MonoBehaviour
{

    public Text healthText;
    public Player player;

    private int half;


    void Start() {

        half = player.maxHealth / 2;

        healthText.text = player.health.ToString();
    }


    void Update() {
        healthText.text = player.health.ToString();

        // Change to Green
        if (player.health > player.maxHealth / 2)
        {
            healthText.color = Color.green;
        }
        // Change to yellow
        else if (player.health <= (player.maxHealth / 2) && player.health > (player.maxHealth / 3))
        {
            healthText.color = Color.yellow;
        }
        // Change to Red
        else if(player.health <= player.maxHealth/3) {
            healthText.color = Color.red;
        }
    }

}
