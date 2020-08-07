using System;
using UnityEngine;

namespace SpriteFPS.General {
    public class Player : MonoBehaviour {
        public float speed;

        private float moveX;
        private float moveZ;
        private float rotateY;

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
        }

        // The physic update function
        void FixedUpdate() {
            Move();

            Turn();
        }

        // The function that handles the calls to move the player using vector math
        private void Move() {
            // Use the two store floats to create a new Vector3 variable movement.
            Vector3 movement = new Vector3(moveX, 0, moveZ);

            movement = movement.normalized * speed * Time.deltaTime;

            playerRigidbody.MovePosition(playerRigidbody.position + movement);
        }

        // Moves the player around the world
        private void Turn() {
            float rotateX = 0;/// 5 * -Input.GetAxis("Mouse Y");

            rotateY  = 5 * Input.GetAxis("Mouse X");
            
            this.transform.Rotate(rotateX, rotateY, 0);
        }
    }
}