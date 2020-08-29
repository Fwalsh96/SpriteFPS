using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject {

    public int ID;
    public new string name;

    public Sprite pickupSprite;

    public int effect;



}
