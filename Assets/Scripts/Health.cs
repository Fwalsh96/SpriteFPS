using SpriteFPS.General;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Player user;

    public new string name;
    public string hudText;

    public int healthNum;


    private void OnTriggerEnter(Collider hit)
    {
        // Check to see if the user needs health
        if (user.health < user.maxHealth) {

            // Check for overflow
            if ((user.health + healthNum) > user.maxHealth)
            {

                user.health = user.maxHealth;
            }
            else {
                user.health += healthNum;
            }

            // Destroy game object
        }
    }
}
