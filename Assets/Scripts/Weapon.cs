using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.WSA.Input;

[CreateAssetMenu(fileName ="New Weapon", menuName = "Weapons")]
public class Weapon : ScriptableObject {

    // Weapon information variables
    public new string name;
    public string description;

    // Sprite Variables
    public Sprite firstPersonView;
    public Sprite pickupView;

    // Projectile that is fired
    public GameObject projectile;

    public int ammo;
    public int damage;
    public int projectileNum;
    public bool isLethal;

    // Fire Rate Variables
    public float fireRate;
    public float nextFire = 0f;

}
