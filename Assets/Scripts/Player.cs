﻿using System;
using UnityEngine;

namespace SpriteFPS.General {
    public class Player : MonoBehaviour {

        public float speed;
        private float moveX;
        private float moveZ;
        private float rotateY;

        public Camera mainView;

        //public Interactable button;

        private Rigidbody playerRigidbody;

        // Use this for initialization
        void Start() {
            speed = 8f;

            moveX = 0;
            moveZ = 0;

            Cursor.lockState = CursorLockMode.Locked;
        }

        void Awake() {
            // The player object is not destroyed when loading a new scene
            //DontDestroyOnLoad(this);

            playerRigidbody = GetComponent<Rigidbody>();

        }

        private void OnEnable() {
            // When the object is turned on, make sure it's not kinematic.
            playerRigidbody.isKinematic = false;
        }

        // Update is called once per frame
        void Update() {
            // Store the current horizontal input in the float move_horizontal.
            moveX = Input.GetAxis("Horizontal");

            // Store the current vertical input in the float move_vertical.
            moveZ = Input.GetAxis("Vertical");

            Interact();
            // This doesnt work

        }

        // The physic update function
        void FixedUpdate() {
            Move();

            Turn();
        }

        // The function that handles the calls to move the player using vector math
        private void Move() {
            // Moves the player based on their direction
            Vector3 movement = transform.right * moveX + transform.forward * moveZ;

            // Add the speed and only applies this calculation per second
            movement = movement.normalized * speed * Time.deltaTime;

            // Apply the movement
            playerRigidbody.MovePosition(playerRigidbody.position + movement);

        }

        // Moves the player around the world
        private void Turn() {
            float mouseSensivity = 100f;

            transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensivity, 0);
        }

        private void Interact() {
            //Debug.LogError("Interact Function Ran");

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Button Pressed");

                // Created a ray that goes from the user's view
                Ray ray = mainView.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                // If the Ray hits something
                if (Physics.Raycast(ray, out hit, 100)) {

                    // Get the interactible object
                    Interactable interactable = hit.collider.GetComponent<Interactable>();

                    // Preform some action
                    if (interactable != null) {

                        interactable.activate();

                    }
                }
            }
        }
    }


}