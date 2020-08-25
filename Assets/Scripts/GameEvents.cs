using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    // Function for elevator height changes
    public event Action<int> onElevatorTriggerRaise;
    public void ElevatorTriggerRaise(int id) {

        if (onElevatorTriggerRaise != null) {

            Debug.Log("Made it to the Elevator Trigger Raise Function"); 

            onElevatorTriggerRaise(id);
        }
    }

    // Function for sprite activation
    public event Action<int> onSpriteActivate;
    public void SpriteActivate(int id) {
    
    }

    // Function for doors
    public event Action<int> onDoorTriggerOpen;
    public void DoorTriggerOpen(int id) {

        if (onDoorTriggerOpen != null) {

            Debug.Log("Inside Game Events for Dorrs");

            onDoorTriggerOpen(id);
        }
    
    }

}
