using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public InteractionController theObject;

    // How close the player needs to be to interact with the object.
    public float radius = 3f;

    public void activate() {

        Debug.Log("Hit Activate");

        switch (theObject.tag) {
            case "Elevator":
                GameEvents.current.ElevatorTriggerRaise(theObject.id);
                break;

            case "Door":
                Debug.Log("Made it to door case");
                GameEvents.current.DoorTriggerOpen(theObject.id);
                break;

            case "SpriteObject":
                GameEvents.current.SpriteActivate(theObject.id);
                break;

        
        }

        
    }
}
