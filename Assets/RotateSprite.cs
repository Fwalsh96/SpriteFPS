using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSprite : MonoBehaviour
{
    public Camera theCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // This code causees the sprite to rotate based on where the camera. It is super buggy.
        this.transform.Rotate(0, theCamera.transform.rotation.y, 0, 0);
    }
}
