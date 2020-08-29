using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : ScriptableObject {

    public new string name;
    public string description;

    public Sprite firstPersonView;

    public Sprite pickupView;

    public int ammo;
    public int damage;

    private void OnTriggerEnter(Collider hit)
    {
        
    }

}
