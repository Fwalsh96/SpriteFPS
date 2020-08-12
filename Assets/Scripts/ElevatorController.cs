using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    Vector3 upperPosition = new Vector3();
    Vector3 defaultPosition = new Vector3();
    //Vector3 tempPosition = new Vector3();

    public float speed;
    float step;

    //public bool activated = false;

    private Rigidbody elevatorRB;

    // Start is called before the first frame update
    private void Start()
    {
        //elevatorRB = GetComponent<Rigidbody>();

        speed = 5;

       GameEvents.current.onElevatorTriggerRaise += OnElevatorRaise;

        defaultPosition = transform.position;

        step = 20 * Time.deltaTime;
    }

    /*
    private void FixedUpdate()
    {
        if (activated == true) {

            // Activate the action
            OnElevatorRaise();

            // reset the activation
            activated = false;
        }
    }
    */

    private void Awake()
    {
       elevatorRB = GetComponent<Rigidbody>();
    }

    private void OnElevatorRaise() {

        Debug.Log("Made it to OnElevatorRaise");

        StartCoroutine(fullElevatorFunction());

    }

    public IEnumerator fullElevatorFunction()
    {
        //yield return new WaitForSeconds(4);
        Invoke("movetoUpper", 3);
        //movetoUpper();

        yield return new WaitForSeconds(6);

        movetoDefault();
        //Invoke("movetoDefault", 5);
    }

    public void movetoUpper()
    {
        Debug.Log("Move up ran");
        /*
        // BASIC MOVEMENT WAY DOESNT WORK
        upperPosition = new Vector3(defaultPosition.x, defaultPosition.y + 5, defaultPosition.z);
        
        transform.position = Vector3.MoveTowards(defaultPosition, upperPosition, 5);
        */

        /*
         /// RIGIDBODY CODE
         // Moves the player based on their direction
         Vector3 movement = transform.up * 5f;

         // Add the speed and only applies this calculation per second
         movement = movement.normalized * speed * Time.deltaTime;

         // Apply the movement
         elevatorRB.MovePosition(elevatorRB.position + movement);
        */
        //transform.position = Vector3.MoveTowards(transform.position, upperPosition, Time.deltaTime * speed);

        // Using LeanTWEEN
        LeanTween.moveLocalY(gameObject, gameObject.transform.position.y + 1.6f, 1f).setEaseOutQuad();
        
    }

    public void movetoDefault()
    {
        Debug.Log("move back ran");

        //transform.position = Vector3.MoveTowards(upperPosition, defaultPosition, 5);


        //transform.position = Vector3.MoveTowards(transform.position, defaultLocation, Time.deltaTime * speed);
        //transform.position = Vector3.MoveTowards(transform.position, upperlocation, Time.deltaTime * speed);


        LeanTween.moveLocalY(gameObject, gameObject.transform.position.y - 1.6f, 1f).setEaseOutQuad();
    }

    
}
