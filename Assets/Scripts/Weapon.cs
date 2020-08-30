using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

[CreateAssetMenu(fileName ="New Weapon", menuName = "Weapons")]
public class Weapon : ScriptableObject {

    public new string name;
    public string description;

    public Sprite firstPersonView;

    public Sprite pickupView;

    public int ammo;
    public int damage;
    public int projectileNum;
    public bool isLethal;

}
