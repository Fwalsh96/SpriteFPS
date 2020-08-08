using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoPickupBehavior : MonoBehaviour
{

    Vector2 offsetPosition = new Vector2();
    Vector2 tempPosition = new Vector2();

    public float amplitude = 0.5f;
    public float frequency = 1f;

    // Start is called before the first frame update
    void Start()
    {
        offsetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Set the temp position to the current position.
        tempPosition = offsetPosition;
        
        // Calculate where the new y will be.
        tempPosition.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        // Set the new position.
        transform.position = tempPosition;

    }
}
