using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO Create an item pickup

public class Inventory : MonoBehaviour {
    public static Inventory instance;

    // Start is called before the first frame update
    void Start() {
        
    }

    private void Awake() {
        if (instance != null) {
            Debug.LogWarning("More than one instance of Inventory found!");

            return;
        }

        instance = this;
    }

    // Update is called once per frame
    void Update() {
        
    }
}
