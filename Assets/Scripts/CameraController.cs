using SpriteFPS.General;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private float mouseSensivity;

    [SerializeField]
    private GameObject player;

    // Start is called before the first frame update
    void Start() {
        mouseSensivity = 100f;
    }

    // Update is called once per frame
    void Update() {
        transform.Rotate(-Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensivity, 0, 0);

        player.transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensivity, 0);
    }
}
