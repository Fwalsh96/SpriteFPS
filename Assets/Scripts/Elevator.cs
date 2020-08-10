using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    // Variables
    public float speed;
    //Vector3 upperlocation;
    //Vector3 defaultLocation;
    public bool triggered;

    

    //private Rigidbody elevatorRB;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5;

        //defaultLocation = transform.position;
        //upperlocation = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);

        triggered = false;

        //StartCoroutine(elevatorWait());
    }



    // Update is called once per frame
    void Update()
    {


    }



}
