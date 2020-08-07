using System;
using UnityEngine;

namespace SpriteFPS.General {
    public class Player : MonoBehaviour {
        public float speed;

        private float xRotation;
        private float mouseSensitivity;

        private float x;
        private float z;

        private Rigidbody playerRigidbody;
        private Transform playerBody;
        

        // Use this for initialization
        void Start() {
            speed = 8f;
            
            x = 0;
            z = 0;

            xRotation = 0f;

            Cursor.lockState = CursorLockMode.Locked;
        }

        void Awake() {
            // The player object is not destroyed when loading a new scene
            //DontDestroyOnLoad(this);

            playerRigidbody = GetComponent<Rigidbody>();
            playerBody = GetComponent<Transform>();
        }

        private void OnEnable() {
            // When the object is turned on, make sure it's not kinematic.
            playerRigidbody.isKinematic = false;
        }

        // Update is called once per frame
        void Update() {
            // Store the current horizontal input in the float move_horizontal.
            x = Input.GetAxis("Horizontal");

            // Store the current vertical input in the float move_vertical.
            z = Input.GetAxis("Vertical");
        }

        // The physic update function
        void FixedUpdate() {
            Move();

            Turn();
        }

        // The function that handles the calls to move the player using vector math
        private void Move() {
            // Use the two store floats to create a new Vector3 variable movement.
            Vector3 movement = new Vector3(x, 0f, z);

            movement = movement.normalized * speed * Time.deltaTime;

            playerRigidbody.MovePosition(playerRigidbody.position + movement);
        }

        // Moves the player around the world
        private void Turn() {
            float rotateX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float rotateY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= rotateY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * rotateX);
        }
    }
}