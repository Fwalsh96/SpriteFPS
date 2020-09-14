using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableWallScript : MonoBehaviour
{

    // When projectiles of a specific tag enter destroy object
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile") {
            this.gameObject.SetActive(false);
            //Destroy(this);
        }
    }
}
