using SpriteFPS.General;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private float sensivity = 100f;
    private float minRotation = -45.0f;
    private float maxRotation = 45.0f;

    private float rotateX;

    [SerializeField]
    private GameObject player;

    // Start is called before the first frame update
    void Start() {
        
    }
    
    private void Awake() {
        rotateX = 0.0f;
    }

    // Update is called once per frame
    void Update() {
        rotateX += -Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;

        // Restrict the camera from going past the min or max rotation
        rotateX = Mathf.Clamp(rotateX, minRotation, maxRotation);

        // Rotates the camera up or down
        transform.localRotation = Quaternion.Euler(rotateX, 0.0f, 0.0f);
    }
}
