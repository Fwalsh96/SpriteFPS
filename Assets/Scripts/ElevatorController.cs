using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    Vector3 upperPosition = new Vector3();
    Vector3 defaultPosition = new Vector3();

    Vector2 offsetPosition = new Vector3();
    Vector2 tempPosition = new Vector3();

    float step;

    // Start is called before the first frame update
    private void Start()
    {
       GameEvents.current.onElevatorTriggerRaise += OnElevatorRaise;

        defaultPosition = transform.position;

        step = 20 * Time.deltaTime;
    }

    private void OnElevatorRaise() {

        Debug.Log("Made it to OnElevatorRaise");

        // This Line doesnt work
        //transform.position += this.transform.up * Time.deltaTime;

        // The Movement needs to be adjusted but it does work.

        // Set the upper position
        upperPosition = new Vector3(defaultPosition.x, defaultPosition.y + 5, defaultPosition.z);

        StartCoroutine(fullElevatorFunction());



        //transform.position = Vector3.MoveTowards(defaultPosition, upperPosition, 5);

        // Set the new position.
        //transform.position = tempPosition;

    }

    public IEnumerator fullElevatorFunction()
    {

        //Invoke("movetoUpper", 2);
        movetoUpper();

        yield return new WaitForSeconds(5);

        movetoDefault();
        //Invoke("movetoDefault", 5);
    }


    public void movetoUpper()
    {
        Debug.Log("Move up ran");

        upperPosition = new Vector3(defaultPosition.x, defaultPosition.y + 5, defaultPosition.z);

        
        transform.position = Vector3.MoveTowards(defaultPosition, upperPosition, 5);

        /// RIGIDBODY CODE
        // Moves the player based on their direction
        //UnityEngine.Vector3 movement = transform.up * 2f;

        // Add the speed and only applies this calculation per second
        //movement = movement.normalized * speed * Time.deltaTime;

        // Apply the movement
        //elevatorRB.MovePosition(elevatorRB.position + movement);

        //transform.position = Vector3.MoveTowards(transform.position, upperlocation, Time.deltaTime * speed);
    }

    public void movetoDefault()
    {
        Debug.Log("move back ran");

        transform.position = Vector3.MoveTowards(upperPosition, defaultPosition, 5);


        //transform.position = Vector3.MoveTowards(transform.position, defaultLocation, Time.deltaTime * speed);
        //transform.position = Vector3.MoveTowards(transform.position, upperlocation, Time.deltaTime * speed);
    }


}
