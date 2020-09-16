using SpriteFPS.General;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorUI : MonoBehaviour
{

    public Text armorText;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        armorText.text = player.armor.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        armorText.text = player.armor.ToString();
    }
}
