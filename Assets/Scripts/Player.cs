using System;
using UnityEngine;

namespace SpriteFPS.General {
    public class Player : MonoBehaviour {
        public float speed;

        int floorMask;
        float camRayLength = 100f;

        private float moveX;
        private float moveZ;
        private float rotateY;

        private Rigidbody playerRigidbody;

        // Use this for initialization
        void Start() {
            speed = 8f;

            moveX = 0;
            moveZ = 0;

            floorMask = LayerMask.GetMask("Floor");

            camRayLength = 100f;

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

            //Turn();
        }

        // The function that handles the calls to move the player using vector math
        private void Move() {
            // Moves the player based on their direction
            Vector3 movement = transform.right * moveX + transform.forward * moveZ;

            movement = movement.normalized * speed * Time.deltaTime;

            playerRigidbody.MovePosition(playerRigidbody.position + movement);

            // Use the two store floats to create a new Vector3 variable movement.
            //Vector3 movement = new Vector3(moveX, 0f, moveZ);

            //movement = movement.normalized * speed * Time.deltaTime;

            //playerRigidbody.MovePosition(playerRigidbody.position + movement);
        }

        // Moves the player around the world
        private void Turn() {
            float rotateX = 250 * -Input.GetAxis("Mouse Y") * Time.deltaTime;

            this.transform.Rotate(rotateX, 0, 0);
        }

        //private void Turn() {
        //    // Create a ray from the mouse cursor on screen in the direction of the camera.
        //    Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    // Create a RaycastHit variable to store information about what was hit by the ray.
        //    RaycastHit floorHit;

        //    // Perform the raycast and if it hits something on the floor layer...
        //    if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask)) {
        //        // Create a vector from the player to the point on the floor the raycast from the mouse hit.
        //        Vector3 playerToMouse = floorHit.point - transform.position;

        //        // Ensure the vector is entirely along the floor plane.
        //        playerToMouse.y = 0f;

        //        // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
        //        Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

        //        // Set the player's rotation to this new rotation.
        //        playerRigidbody.MoveRotation(newRotation);
        //    }
        //}
    }
}