using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Create an item pickup

public class Inventory : MonoBehaviour {
    public static Inventory instance;

    //private List<ItemStats> items = new List<ItemStats>();     // Current list of all items in inventory

    private void Awake() {
        if (instance != null) {
            Debug.LogWarning("More than one instance of Inventory found!");

            return;
        }

        instance = this;
    }

    //public bool Add(ItemStats item) {
    //    if (!item.isDefaultItem) {
    //        if (items.Count >= space) {
    //            Debug.Log("Not enough room");
    //            return false;
    //        }

    //        items.Add(item);

    //        if (onItemChangedCallback != null)
    //            onItemChangedCallback.Invoke();
    //    }

    //    return true;
    //}

    //public void Remove(ItemStats item) {
    //    items.Remove(item);

    //    if (onItemChangedCallback != null)
    //        onItemChangedCallback.Invoke();
    //}
}