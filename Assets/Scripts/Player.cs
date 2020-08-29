using System;
using UnityEngine;

//TODO: Look into sprinting bool

namespace SpriteFPS.General {
    public class Player : MonoBehaviour {

        #region Variables
        KeyCode moveUpButton;
        KeyCode moveLeftButton;
        KeyCode moveDownButton;
        KeyCode moveRightButton;
        KeyCode interactButton;

        private float speed;
        private float walkingSpeed;

        // Player Stats
        public int maxHealth = 100;
        public int maxArmor = 100;
        public int health = 100;
        public int armor = 100;
        int[] ammo;
        Weapon[] weapons;

        private bool sprinting;

        public Camera mainView;

        private Rigidbody playerRigidbody;
        #endregion

        #region General

        // Use this for initialization
        void Start() {
            moveUpButton = KeyCode.W;
            moveLeftButton = KeyCode.A;
            moveDownButton = KeyCode.S;
            moveRightButton = KeyCode.D;
            interactButton = KeyCode.E;

            speed = 12f;
            walkingSpeed = 8f;

            sprinting = false;

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
        private void Update() {
            if (Input.GetKey(moveUpButton))
                playerRigidbody.MovePosition(playerRigidbody.position + Move(0, 1));

            if (Input.GetKey(moveLeftButton))
                playerRigidbody.MovePosition(playerRigidbody.position + Move(-1, 0));

            if (Input.GetKey(moveDownButton))
                playerRigidbody.MovePosition(playerRigidbody.position + Move(0, -1));

            if (Input.GetKey(moveRightButton))
                playerRigidbody.MovePosition(playerRigidbody.position + Move(1, 0));

            // Check to see if the player has to sprint
            if (Input.GetButton("Fire3"))
                sprinting = !sprinting;

            Interact();
        }

        // The physic update function
        private void FixedUpdate() {
            Turn();

            if (sprinting == true)
                Debug.Log("Player is sprinting");
        }

        #endregion

        #region Movement

        private Vector3 Move(float moveX, float moveZ) {
            // Moves the player based on their direction
            Vector3 movement = transform.right * moveX + transform.forward * moveZ;

            Debug.Log("moveX: " + moveX.ToString());
            Debug.Log("moveZ: " + moveZ.ToString());

            // Add the sprinting speed if it applies
            if (sprinting) {
                movement = movement.normalized * speed * Time.deltaTime;
            } else {
                // Add the speed and apply this calculation per second
                movement = movement.normalized * walkingSpeed * Time.deltaTime;
            }

            return movement;
        }

        // Moves the player around the world
        private void Turn() {
            float mouseSensivity = 100f;

            transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensivity, 0);
        }

        #endregion

        #region Interact

        private void Interact() {
            //Debug.LogError("Interact Function Ran");

            if (Input.GetKeyDown(interactButton))
            {
                //Debug.Log("Button Pressed");

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

        #endregion

        #region Misc

        public float Speed {
            get {
                return 12f;
            }

            set {
                speed = value;
            }
        }

        public float WalkingSpeed {
            get {
                return 8f;
            }

            set {
                walkingSpeed = value;
            }
        }
        
        #endregion
    }


}