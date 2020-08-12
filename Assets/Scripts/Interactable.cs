﻿using UnityEngine;

public class Interactable : MonoBehaviour
{
    public ElevatorController theObject;


    // How close the player needs to be to interact with the object.
    public float radius = 3f;

    public void activate() {

        Debug.Log("Hit Activate");

        GameEvents.current.ElevatorTriggerRaise(theObject.id);
    }
}
