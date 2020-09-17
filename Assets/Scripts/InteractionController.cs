using System.Collections;
using System.Collections.Generic;
using UnityEditor.Scripting;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public float movementVar;
    public int id;

    Vector3 startLocation;
    Vector3 MoveLocation;

    // Variable that will be true or false depending on wheter the object has arrived or not.
    public bool isMoving;
    

    // Start is called before the first frame update
    private void Start() {

        // Set the start and move locations
        startLocation = this.transform.position;
        MoveLocation = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - movementVar);

        //GameEvents.current.onDoorTriggerOpen += OnDoorOpen;

        // Get the tag and check what function is needed
        switch (this.tag) {
            case "Elevator":
                Debug.Log("Elevator case ran");
                GameEvents.current.onElevatorTriggerRaise += OnElevatorRaise;
                break;
            case "Door":
                Debug.Log("Hit other case for door");
                GameEvents.current.onDoorTriggerOpen += OnDoorOpen;
                break;
            default:
                // Interactable object does nothing
                // add to the log that object does nothing.
                Debug.Log("Default Case");
                break;
        }
    }





    #region Sliding Door Functions

    // Function to start the Door functions
    private void OnDoorOpen(int id)
    {
        Debug.Log("made it to onDoorOpen");

        if (id == this.id)
        {

            StartCoroutine(fullDoorFunction());

        }
    }

    // Function that handles door opening then closing.
    public IEnumerator fullDoorFunction()
    {
        Debug.Log("Made it to door enumerator");

        moveIntoWall();
        
        // Door stops moving and waits
        yield return new WaitForSeconds(5);

        moveOutWall();

    }



    // Function that slides a door into the wall
    public void moveIntoWall()
    {
        Debug.Log("Made it to move into wall");

        isMoving = true;

        // Slide the door
        LeanTween.moveLocalZ(gameObject, MoveLocation.z, 1f).setEaseOutQuad();

    }

    public void moveOutWall() {

        Debug.Log("Made it ot move out function");

        isMoving = true;

        LeanTween.moveLocalZ(gameObject, startLocation.z, 1f).setEaseOutQuad();
    }
    #endregion


    #region Elevator Functions

    // Function to start the elevator function
    private void OnElevatorRaise(int id)
    {

        Debug.Log("Made it to OnElevatorRaise");
        if (id == this.id)
        {
            StartCoroutine(fullElevatorFunction());
        }

    }

    // Function that handles the wait time between the raise and lowwering of the elevator
    public IEnumerator fullElevatorFunction()
    {
        Invoke("MoveToUpper", 3);

        yield return new WaitForSeconds(6);

        movetoDefault();
    }

    // Function that raises the elevator.
    public void MoveToUpper()
    {
        Debug.Log("Move up ran");


        // Raise the Elevator
        LeanTween.moveLocalY(gameObject, gameObject.transform.position.y + movementVar, 1f).setEaseOutQuad();

    }

    // Function that lowers the elevator back to a default position.
    public void movetoDefault()
    {
        Debug.Log("move back ran");

        // Lower the Elevator
        LeanTween.moveLocalY(gameObject, gameObject.transform.position.y - movementVar, 1f).setEaseOutQuad();
    }

    #endregion
}
