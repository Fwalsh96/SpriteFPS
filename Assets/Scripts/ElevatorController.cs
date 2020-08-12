using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public float raiseHeight;
    public int id;

    // Start is called before the first frame update
    private void Start()
    {

       GameEvents.current.onElevatorTriggerRaise += OnElevatorRaise;

    }

    private void OnElevatorRaise(int id) {

        Debug.Log("Made it to OnElevatorRaise");
        if (id == this.id) 
        {
            StartCoroutine(fullElevatorFunction());
        }
        

    }

    // Function that handles the wait time between the raise and lowwering of the elevator
    public IEnumerator fullElevatorFunction()
    {
        Invoke("movetoUpper", 3);
   
        yield return new WaitForSeconds(6);

        movetoDefault();
    }

    // Function that raises the elevator.
    public void movetoUpper()
    {
        Debug.Log("Move up ran");


        // Raise the Elevator
        LeanTween.moveLocalY(gameObject, gameObject.transform.position.y + raiseHeight, 1f).setEaseOutQuad();
        
    }

    // Function that lowers the elevator back to a default position.
    public void movetoDefault()
    {
        Debug.Log("move back ran");

        // Lower the Elevator
        LeanTween.moveLocalY(gameObject, gameObject.transform.position.y - raiseHeight, 1f).setEaseOutQuad();
    }

    
}
