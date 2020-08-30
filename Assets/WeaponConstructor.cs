using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponConstructor : MonoBehaviour
{

    public Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider hit)
    {
        //Debug.Log("Player Hit Item");
        // Check to see if player has weapon or not.
        if (hit.gameObject.name == "Player")
        {
            Debug.Log("Player Hit Item");
        }

        // If player has weapon already, add some ammo to their inventory.

        // Otherwise add weapon to the right weapon slot.
    }
}
