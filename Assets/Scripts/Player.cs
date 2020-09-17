using System;
//using System.Security.Policy;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//TODO: Look into sprinting bool

namespace SpriteFPS.General {
    public class Player : MonoBehaviour {

        #region Variables
        KeyCode moveUpButton;
        KeyCode moveLeftButton;
        KeyCode moveDownButton;
        KeyCode moveRightButton;
        KeyCode interactButton;
        KeyCode fireButton;
        public KeyCode pauseButton;
        
        
        KeyCode weaponOne;
        /*
        KeyCode weaponTwo;
        KeyCode weaponThree;
        KeyCode weaponFour;
        KeyCode weaponFive;
        */

        private float speed;
        private float walkingSpeed;
        private bool allowFire = true;

        // Player Stats
        public int maxHealth = 100;
        public int maxArmor = 100;
        public int health = 100;
        public int armor = 100;
        int[] ammo;
        public Weapon[] weapons = new Weapon[7];
        public Weapon equippedWeapon;
        public GameObject currentProjectile;
        public Image fpsSprite;
        public GameObject projectileEmitter;
        private bool sprinting;

        public Camera mainView;

        private Rigidbody playerRigidbody;
        #endregion

        #region General

        // Use this for initialization
        void Start() {
            // Assigning Keycodes
            moveUpButton = KeyCode.W;
            moveLeftButton = KeyCode.A;
            moveDownButton = KeyCode.S;
            moveRightButton = KeyCode.D;
            interactButton = KeyCode.E;
            weaponOne = KeyCode.Alpha1;
            fireButton = KeyCode.Mouse0;
            pauseButton = KeyCode.Escape;

            // Preparing HUD
            fpsSprite.gameObject.SetActive(false);
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

            if (Input.GetKey(weaponOne)) {
                Equip(1);
            }

            // Weapon Firing Mechanics
            if (equippedWeapon != null) {

                if (equippedWeapon.ammo > 0) {
                    
                    //&& Time.time > equippedWeapon.nextFire
                    if (Input.GetKeyDown(fireButton) && (allowFire)) {

                        StartCoroutine("fire");
                    }
                }
                else {
                    Debug.Log("You are out of ammo");
                }
            }

            //Debug.Log("Entered If Statement");

        }

        // Weapon firing coroutine
        IEnumerator fire() {

            // Set allow Fire false
            allowFire = false;

            // Create the projectile
            Rigidbody instantiatedProjectile = Instantiate(currentProjectile.GetComponent<Rigidbody>(), projectileEmitter.transform.position, projectileEmitter.transform.rotation) as Rigidbody;

            // Fire projectile
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, 150));

            // Wait firerate
            yield return new WaitForSeconds(5f);

            // Set allow fire true
            allowFire = true;
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

            //Debug.Log("moveX: " + moveX.ToString());
            //Debug.Log("moveZ: " + moveZ.ToString());

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

        #region Equip

        private void Equip(int i) {

            switch (i) {

                case 1:

                    if (weapons[0] != null) {
                        Debug.Log("Weapon Equipped");
                        this.equippedWeapon = weapons[0];
                        fpsSprite.sprite = equippedWeapon.firstPersonView;
                        currentProjectile = weapons[0].projectile;
                        fpsSprite.gameObject.SetActive(true);
                    }

                 break;
            }
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


        #region Collision

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Projectile") {

                health = health - 5;
            }
        }
        #endregion
    }


}