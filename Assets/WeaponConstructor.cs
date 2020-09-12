using SpriteFPS.General;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponConstructor : MonoBehaviour
{

    public Weapon weapon;
    public Player user;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider hit)
    {
        //Debug.Log("Player Hit Item");
        // Check to see if player has weapon or not.
        if (hit.gameObject.tag == "Player")
        {
            Debug.Log("Picked up weapon");

            // If player doenst have the weapon.
            user.weapons[0] = this.weapon;
        }

        // If player has weapon already, add some ammo to their inventory.

        // Otherwise add weapon to the right weapon slot.
    }


}
