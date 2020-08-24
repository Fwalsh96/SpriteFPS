using SpriteFPS.General;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : ScriptableObject {

    public Player user;


    public new string name;
    public string hudText;


    public int armorVal;


    private void OnTriggerEnter(Collider hit)
    {
        // Check to see if the user needs health
        if (user.health < user.maxArmor)
        {

            // Check for overflow
            if ((user.armor + armorVal) > user.maxArmor)
            {

                user.armor = user.maxArmor;
            }
            else
            {
                user.armor += armorVal;
            }

            // Destroy game object
        }
    }
}
