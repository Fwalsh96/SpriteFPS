using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    
    public static GameEvents current;

    // 
    private void Awake()
    {
        current = this;
    }

    public event Action onElevatorTriggerRaise;
    public void ElevatorTriggerRaise() {

        if (onElevatorTriggerRaise != null) {

            Debug.Log("Made it to the Elevator Trigger Raise Function"); 

            onElevatorTriggerRaise();
        }
    }

}
