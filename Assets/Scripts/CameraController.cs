using SpriteFPS.General;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private GameObject player;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        float mouseSensivity = 100f;

        transform.Rotate(-Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensivity, 0, 0);
    }
}
