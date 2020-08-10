using UnityEngine;

public class Interactable : MonoBehaviour
{
    // How close the player needs to be to interact with the object.
    public float radius = 3f;

    public void activate() {

        Debug.Log("Hit Activate");


        //StartCoroutine(movingObject.elevatorBack());


        //movingObject.triggered = true;


        GameEvents.current.ElevatorTriggerRaise();
    }
    

}
